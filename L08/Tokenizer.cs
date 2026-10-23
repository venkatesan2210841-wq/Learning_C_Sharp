using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace L08 {
   // Reads the input expression and converts it into a sequence of Token objects.
   class Tokenizer {
      public Tokenizer (Evaluator eval,string input) {
         mText = input; mEval = eval;
         mN = 0;
      }
      readonly string mText;
      readonly Evaluator mEval;
      int mN;
      public Token GetNext () {
         while (mN < mText.Length) {
            char ch = mText[mN++];
            if (ch == ' ') continue;
            if (ch is '+' or '-' or '/' or '^' or '*' or '=') return new TOpBinary (ch);
            if (ch is >= '0' and <= '9') return GetLiteral ();
            if (ch is '(' or ')') return new TPunctuation (ch);
            if (ch is >= 'a' and <= 'z') return GetIdentifier ();
            return new TError ($"Unexpected character {ch}");
         }

         return new TEnd ();
      }
      Token GetIdentifier () {
         int start = mN - 1;
         while (mN < mText.Length) {
            char ch = mText[mN++];
            if (ch is (>= 'a' and <= 'z')) continue;
            mN--;
            break;
         }
         string identifier = mText.Substring (start, mN - start);
         if (mFuncs.Contains (identifier)) return new TOpFunction (identifier);
         else return new TVariable (mEval, identifier);
      }
      readonly string[] mFuncs = ["sin", "cos", "tan", "sqrt", "log", "exp", "asin", "acos", "atan"];

      public Tokenizer (string[] mFuncs) {
         this.mFuncs = mFuncs;
      }

      Token GetLiteral () {
         int start = mN - 1;
         while (mN < mText.Length) {
            char ch = mText[mN++];
            if (ch is (>= '0' and <= '9') or '.') continue;
            mN--;
            break;
         }

         // separated the string from the opeaator-> we get literal
         string number = mText.Substring (start, mN - start);
         double f = double.Parse (number);
         return new TLiteral (f);
      }
   }
}

