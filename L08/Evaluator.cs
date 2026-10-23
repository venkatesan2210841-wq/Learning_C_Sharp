using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace L08 {
   class EvalException : Exception {
      public EvalException (string message) : base (message) { }
   }

   // class to get tokens and process it.
   class Evaluator {
      public double Evaluate (string input) {
         mOperator.Clear ();
         mOperand.Clear ();
         mBasePriority = 0;//parenthesis
         var tokenizer = new Tokenizer (this, input);
         List<Token> tokens = []; // assignment expression
         for (; ; ) {
            var token = tokenizer.GetNext ();
            // return next token if Tend token
            if (token is TEnd) break;
            tokens.Add (token);
         }
         TVariable var = null;
         if (tokens[0] is TVariable tv && tokens[1] is TOpBinary bin && bin.Op == '=') {
            var = tv;
            tokens.RemoveRange (0, 2);
         }
         while (mOperator.Count > 0)
            ApplyOperator ();
         if (mBasePriority != 0) Error ("Mismatched parentheses"); //parantheses
         if (mOperator.Count > 0) Error ("Too many operators");
         if (mOperand.Count > 1) Error ("Too many operators");
         double f = mOperand.Pop ();
         if (var != null)
            mVariable[var.Ov] = f;
         return f;
      }
      void ApplyOperator () {
         var op = mOperator.Pop ();
         if (op is TOpBinary bin) {
            if (mOperand.Count < 2) Error ("Too many operands"); //for stack empty
            double r = mOperand.Pop (), l = mOperand.Pop ();
            mOperand.Push (bin.Apply (l, r));
         }
         if (op is TOpFunction func) {
            if (mOperand.Count < 1) Error ("Too few operands"); //for stack empty
            double a = mOperand.Pop ();
            mOperand.Push (func.Apply (a));
         }
      }

      void Error (string s) => throw new EvalException (s);
      void Process (Token token) {
         switch (token) {
            case TNumber num:
               mOperand.Push (num.Value);
               break;
            case TOperator op:
               op.FinalPriority = op.Priority + mBasePriority; //parenthesis
               while (!OkToPush (op))
                  ApplyOperator ();
               mOperator.Push (op);
               break;
            case TPunctuation p:
               if (p.ch == '(') mBasePriority += 10;
               else mBasePriority -= 10;
               break; //parenthesis
            default: throw new NotImplementedException ();
         }
      }
      int mBasePriority = 0; //parenthesis
      bool OkToPush (TOperator op) {
         if (mOperator.Count == 0) return true;
         TOperator prev = mOperator.Peek ();
         return prev.FinalPriority < op.FinalPriority;
      }//operator priority

      public double GetVariable (string name) {
         if (mVariable.TryGetValue (name, out var f))
            return f;
         Error ($"Unknown variable{name}");
         return 0;
      }
      Stack<double> mOperand = [];
      Stack<TOperator> mOperator = [];
      Dictionary<string, double> mVariable = [];
   }
}
