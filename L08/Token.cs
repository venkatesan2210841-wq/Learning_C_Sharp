using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace L08 {
   class Token {
   }
   // Represents a numeric value.
   class TNumber : Token {
      public virtual double Value { get; }
   }
   // Value that assigned to a variable, eg. x=4,y=7;
   class TVariable : TNumber {
      public TVariable(Evaluator eval, string name) { mOv = name; mEval = eval; }
      public override string ToString () => $"Variable: {mOv}";
      public override double Value => mEval.GetVariable (mOv);
      public string Ov => mOv;
      readonly string mOv;
      readonly Evaluator mEval;
   }

   // Represents a numeric literal in the expression, e.g. 5, 12, 3.14.
   class TLiteral : TNumber {
      public TLiteral (double d) => mValue = d;
      public override string ToString () => $"Literal: {mValue}";
      public override double Value => mValue;
      readonly double mValue;
   }


   // Tokens that represent operations.
   class TOperator : Token {
      public virtual int Priority { get; } // to set the priority o=among the opearators and functions
      public int FinalPriority { get; set; } // included for brackets
   }

   // Operator: +,-, ^,*,/, %
   class TOpBinary : TOperator {
      public TOpBinary (char op) => mOp = op;
      public override string ToString () => $"Operator: {mOp}";
      public override int Priority => Op switch {
         '+' or '-' => 1,
         '*' or '/' => 2,
         '^' => 3,
         _ => throw new NotImplementedException (),
      };
      public double Apply (double a, double b) => Op switch {
         '+' => a + b,
         '-' => a - b,
         '*' => a * b,
         '/' => a / b,
         '^' => Math.Pow (a, b),
         _ => throw new NotImplementedException (),
      };
      public char Op => mOp;
      readonly char mOp;
   }


   // Trignometric function such as sin, cos, tan, log, etc
   class TOpFunction : TOperator {
      public TOpFunction (string of) => mOf = of;
      public override string ToString () => $"Function: {mOf}";
      public override int Priority => 4;
      public double Apply (double a) => Of switch {
         "sin" => Math.Sin (D2R (a)),
         "cos" => Math.Cos (D2R (a)),
         "tan" => Math.Tan (D2R (a)),
         "asin" => R2D (Math.Asin (a)),
         "acos" => R2D (Math.Acos (a)),
         "atan" => R2D (Math.Atan (a)),
         "log" => Math.Log (a),
         "exp" => Math.Exp (a),
         "sqrt" => Math.Sqrt (a),
         _ => throw new NotImplementedException (),
      };
      double D2R (double f) => f * Math.PI / 180;
      double R2D (double f) => f * 180 / Math.PI;
      public string Of => mOf;
      readonly string mOf;
   }
   // Represents '(' or ')' used to group expressions.
   class TPunctuation : Token {
      public TPunctuation (char ch) => mP = ch;
      public override string ToString () => $"Punctuation: {mP}";
      public char ch => mP;
      readonly char mP;
   }
   class TEnd : Token { }

   // Represents an invalid token in the expression.
   class TError : Token {
      public TError (string error) => mError = error;
      public override string ToString () => $"Error:{mError}";
      public string error => mError;
      readonly string mError;
   }
}
