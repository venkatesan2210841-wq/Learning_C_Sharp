using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace L07;

class Program {
   static void Main (string[] args) {
      Console.WriteLine (double.Parse ("+Infinity"));
   }
}
/*
      var testCases = new List<string>
      {
   // ============================================================
   // 1. BASIC INTEGERS
   // ============================================================
   "0",
   "1",
   "9",
   "10",
   "123",
   "999999",
   "-1",
   "-456",
   "+789",
   "+0",
   "-0",

   // ============================================================
   // 2. NORMAL DECIMALS
   // ============================================================
   "67.88902",
   "-45.67",
   "+5.123",
   "123.456",
   "-123.456",
   "+123.456",
   "0.5",
   "-0.5",
   "+0.5",

   // ============================================================
   // 3. LEADING DECIMAL POINT
   // ============================================================
   ".5",
   "-.5",
   "+.5",
   ".0001",
   "-.0001",
   "+.0001",
   ".0",

   // ============================================================
   // 4. TRAILING DECIMAL POINT
   // ============================================================
   "5.",
   "-5.",
   "+5.",
   "0.",
   "1.",
   "123.",

   // ============================================================
   // 5. LEADING / TRAILING ZEROS
   // ============================================================
   "000123",
   "000123.4500",
   "000.000",
   "001.002",
   "-000123.4500",
   "+000123.4500",

   // ============================================================
   // 6. BASIC SCIENTIFIC NOTATION
   // ============================================================
   "1e3",
   "1E3",
   "1e0",
   "1E0",
   "1e1",
   "1e-1",
   "1e+1",
   "1.23e3",
   "1.23E3",
   "4.56E-2",
   "-7.89e+2",
   "+3.2e-5",

   // ============================================================
   // 7. DECIMAL-POINT EDGE CASES WITH EXPONENT
   // ============================================================
   ".5e2",
   "-.5e2",
   "+.5e2",
   "5.e2",
   "-5.e2",
   "+5.e2",
   ".001e3",
   "100.e-2",

   // ============================================================
   // 8. LARGE / SMALL EXPONENTS
   // ============================================================
   "1e10",
   "1e100",
   "1e300",
   "9e999",
   "1e-10",
   "1e-100",
   "1e-300",
   "1e-999",
   "45e-98",

   // ============================================================
   // 9. MULTIPLE DECIMAL POINTS - INVALID
   // ============================================================
   "1.2.3",
   "6.7.78",
   "..5",
   "5..",
   "1..2",
   "...",
   "1.2.3.4",

   // ============================================================
   // 10. MULTIPLE EXPONENTS - INVALID
   // ============================================================
   "1e2e3",
   "1E2E3",
   "1e2E3",
   "1E2e3",
   "1ee2",
   "1EE2",
   "1eE2",
   "1Ee2",

   // ============================================================
   // 11. MISSING MANTISSA - INVALID
   // ============================================================
   "e10",
   "E10",
   "e+10",
   "e-10",
   "E+10",
   "E-10",

   // ============================================================
   // 12. MISSING EXPONENT - INVALID
   // ============================================================
   "1e",
   "1E",
   "1.2e",
   "-1e",
   "+1e",

   // ============================================================
   // 13. EXPONENT SIGN WITHOUT DIGITS - INVALID
   // ============================================================
   "1e+",
   "1e-",
   "1E+",
   "1E-",
   "-1e+",
   "-1e-",

   // ============================================================
   // 14. MULTIPLE SIGNS - INVALID
   // ============================================================
   "++1",
   "--1",
   "+-1",
   "-+1",
   "++1.5",
   "--1.5",
   "+-1.5",
   "-+1.5",

   // ============================================================
   // 15. MULTIPLE SIGNS IN EXPONENT - INVALID
   // ============================================================
   "1e++2",
   "1e--2",
   "1e+-2",
   "1e-+2",
   "1E++2",
   "1E--2",
   "1E+-2",
   "1E-+2",

   // ============================================================
   // 16. SIGNS IN WRONG POSITIONS - INVALID
   // ============================================================
   "1+2",
   "1-2",
   "12+",
   "12-",
   "1.2+3",
   "1.2-3",
   "1e2+",
   "1e2-",

   // ============================================================
   // 17. EMPTY / NO DIGIT CASES - INVALID
   // ============================================================
   "",
   " ",
   "   ",
   "+",
   "-",
   ".",
   "+.",
   "-.",

   // ============================================================
   // 18. LETTERS / OTHER CHARACTERS - INVALID
   // ============================================================
   "abc",
   "12abc",
   "abc12",
   "1a2",
   "1.2f",
   "1d",
   "NaNabc",
   "$123",
   "12#3",

   // ============================================================
   // 19. SPECIAL DOUBLE VALUES
   // ============================================================
   "NaN",
   "Infinity",
   "+Infinity",
   "-Infinity",

   // ============================================================
   // 20. WHITESPACE
   // ============================================================
   "   123.45   ",
   "   -123.45   ",
   "   +123.45   ",

   // Internal whitespace - invalid
   "12 34",
   "1. 5",
   "1 .5",
   "1 e3",
   "1e 3",

   // ============================================================
   // 21. PRECISION / SIZE
   // ============================================================
   "0.0000001",
   "-0.0000001",
   "123456789.123456789",
   "999999999999999",
   "0.1234567890123456789"
};
      foreach (string str in testCases.Select (s => s.Trim ())) {
         double value = ConvertToDouble (str);
         bool success = double.TryParse (str, out double parsed);
         Console.WriteLine ($"{str,15} ---> {value, 15:G15} | {parsed}");
      }
   }

   #region String to Double Implementation
   static double ConvertToDouble (string str) {

      if (string.IsNullOrWhiteSpace (str)) return double.NaN;

      string[] parts = str.Split ('e', 'E');
      if (parts.Length > 2)
         return double.NaN;
      if (parts.Length == 1) return GetMantissa (parts[0]);
      else if (parts.Length == 2) {
         return GetMantissa (parts[0]) * GetExponent (parts[1]);
      } else return double.NaN;
   }

   static double GetMantissa (string str) {
      if (string.IsNullOrEmpty (str)) return double.NaN;
      int sign = 1;
      if (str[0] == '+' || str[0] == '-') {
         if (str[0] == '-')
            sign = -1;

         str = str.Substring (1);
      }
      if (!str.Any (char.IsDigit)) return double.NaN;
      string[] parts = str.Split ('.');
      if (parts.Length > 2) return double.NaN;
      double integerPart = 0;
      if (!string.IsNullOrEmpty (parts[0]))
         integerPart = GetDigits (parts[0]);
      if (parts.Length == 1) return sign * integerPart;
      double fractional = 0;
      if (parts.Length == 2 && !string.IsNullOrEmpty (parts[1])) {
         double decimals = GetDigits (parts[1]);
         fractional = decimals * Math.Pow (10, -parts[1].Length);
      }
      return sign * (integerPart + fractional);
   }
   static double GetExponent (string str) {
      if (string.IsNullOrEmpty (str)) return double.NaN;
      int sign = 1;
      if (str[0] == '+' || str[0] == '-') {
         if (str[0] == '-')
            sign = -1;
         str = str.Substring (1);
      }
      double power = GetDigits (str);
      return Math.Pow (10,sign * power);
   }

   static double GetDecimals (string str) {
      return GetDigits (str);
   }
   static double GetDigits (string str) {
      if (string.IsNullOrEmpty (str)) return double.NaN;
      double digits = 0;
      for (int i = 0; i < str.Length; i++) {
         if (char.IsDigit (str[i])) digits = (digits * 10) + (str[i] - '0');
         else return double.NaN;
      }
      return digits;
   }
   #endregion
}

#region Firts Implementation
//static bool IsValid (string str) {
//   string[] parts = str.Split ('e', 'E');
//   if (parts.Length > 2) return false;

//   return parts.Length switch {
//      1 => IsValidSignificand (parts[0]),
//      2 => IsValidSignificand (parts[0])
//           && IsValidExponent (parts[1]),
//      _ => false
//   };
//}

//static bool IsValidSignificand (string str) {
//   if (string.IsNullOrEmpty (str) || str.Any (char.IsWhiteSpace))
//      return false;

//   int start = str[0] is '+' or '-' ? 1 : 0;
//   return str.Skip (start).All (ch => char.IsDigit (ch) || ch == '.')
//       && str.Count (ch => ch == '.') <= 1
//       && str.Skip (start).Any (char.IsDigit);
//}

//static bool IsValidExponent (string str) {
//   if (string.IsNullOrEmpty (str)|| str.Any (char.IsWhiteSpace))
//      return false;
//   int start = str[0] is '+' or '-' ? 1 : 0;
//   //Skip the optional sign, then check whether all remaining characters are digits, and ensures at least one digit exists
//   return str.Skip (start).All (char.IsDigit)
//       && str.Skip (start).Any (char.IsDigit);
//}
#endregion

/*
var res1 = double.Parse ("+000.000e-000");
Console.WriteLine (res1);
foreach (var str in testCases.Select (s => s.Trim ())) {
   var res = IsCharacterLevelValid (str);
   Console.WriteLine ($"{str,15} --> {res,-10} ");
}
}
static bool IsCharacterLevelValid (string str) =>
HasValidCharacterSet (str) && HasValidCharacterCounts (str);
// A valid decimal cannot contain space between characters
// It only contains allowable characters

// It contain atleast one digit numbers
static bool HasValidCharacterSet (string str) => !string.IsNullOrWhiteSpace (str) &&
str.Any (char.IsDigit) && str.All (ch => char.IsDigit (ch) || sAllowed.Contains (ch));
static bool HasValidCharacterCounts (string str) {
int dotCount = str.Count (ch => ch == sDot);
int expCount = str.Count (ch => sExp.Contains (ch));
int signCount = str.Count (ch => sSign.Contains (ch));
int eIndex = str.IndexOfAny (sExp);
//dot count : 0||1, exponential count =0
return dotCount <= 1 &&
(expCount == 0 && signCount <= 1 ||
(expCount == 1 && (signCount <= 1 || (signCount == 2 && sExp.Contains (str[eIndex + 2])))));
}
static char sDot = '.';
static char[] sExp = { 'e', 'E' };
static char[] sSign = { '-', '+'};
static char[] sAllowed = { sDot, sExp[0], sExp[1], sSign[0], sSign[1] };

//static bool HasValidCharacterCounts (string str) =>
//   str.Count (ch => ch is '.') <= 1 &&
//   ((str.Count (ch => ch is 'e' or 'E') == 0 && str.Count (ch => ch is '-' or '+') <= 1) ||
//   (str.Count (ch => ch is 'e' or 'E') <= 1 && str.Count (ch => ch is '-' or '+') <= 2));

//static bool IsValid (string str) {
//   if (string.IsNullOrWhiteSpace (str)) return false;
//   string strTrim = str.Trim (); // Trims leading and traling spaces
//   // if spaces prsent between the string
//   foreach (char ch in strTrim)
//      if (ch == ' ') return false;
//   // condition : the string must contains at least any one digit. if  not --> false
//   if (!strTrim.Any (char.IsDigit)) return false;
//   char[] allowed = { '1', '2', '3', '4', '5', '6', '7', '8', '9','0', '.', 'e', 'E', '+', '-' };
//   // condition : the string that must contains the any of the allowable characters, if not -> false.
//   if (!strTrim.All (allowed.Contains)) return false;

//   return true;
//}

//Valid Strings
//decimal -> 16 bytes => 128 bits
//"2147483647"->Max 32 - bit signed int
//"2147483648"->Overflow / Error
//"-2147483648"->Min 32 - bit signed int
//"-2147483649"->Overflow / Error
//"9223372036854775807"->Max 64 - bit signed int
//"9223372036854775808"->Overflow / Error
//string str = " + 3 4 . 6 7 ";
//string str1 = " + 3 4 . 6 7 ";
//string str2 = "- 4 5 . ";
//string str3 = " 6 7.89";
//string str4 = " . 509";
//string str5 = "455,67";
//decimal i = (decimal) str;
//string str6 = "";
//if (str < int.MinValue) Console.WriteLine ("less than the size");
var res = double.Parse ("  0.2E7");
Console.WriteLine (res);
string s1 = "40000E300";
bool? b = null;
Console.WriteLine (b);
decimal number = 7.9E28m;

if (number >= decimal.MinValue && number <= decimal.MaxValue) {
   Console.WriteLine ("The number is within the range of decimal.");
} else {
   Console.WriteLine ("The number is out of range.");
}
System.UIntPtr platform = 123;
// Trim leading and trailing whitespaces
string str = "";
string trimWhiteSpace = str.Trim ();

// Not Valid
   //if contains decimals after Exponent--> that consyains an integer so take that token
   //so split the exponenet and convert the remsaining string into valid int

//Rectangle r = new ();
//Console.WriteLine (r.Width);ReadOnlySpan<char> readOnlySpan = string.Trim ("Hello World!");

//Console.WriteLine (r.Height);
//r.Height = 9;
}
}
class Shape {
   public Shape (Point pos) {

   }
}

class Rectangle {
   public double Width {
      get => _width;
      set { _width = value; }
   }
   public double Height {
      get => _height;
      set { _height = value; }
   }
   double _height;
   double _width;
   public Rectangle () {
   }
   public Rectangle (double width, double height) {
      _width = width;
      _height = height;
   }
}
 * Write a program for expression evaluator
 * type an exprssion-> evaluates and get output.
 * take text and break into tokens
 * Inheritance to represent different type of tokens
 * numbers, operator, Literals, paranthesis, identifiers==> fns, variables.
 * Hierachy, base--> derived--> so on.
 * double.Parse>>take string and return double
 * do create withoout using
 * pascal diagram--> pascal syntax diagram in real
 * BNF diagram.
 */