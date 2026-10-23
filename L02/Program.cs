using System;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;
namespace L02;

class Program {
   static void Main (string[] args) {
      Console.WriteLine ("Hello, World!");
      //string s = Console.ReadLine ();
      //Console.WriteLine (s);
      //Console.WriteLine (Console.ReadLine ());   //optimised line
      ////Composite formatted Strings -placeholder
      //Console.WriteLine ("Hello {0} Welcome to {1}", s, "Trumpf Metamation");
      ////Interpolates strings
      //Console.WriteLine ($"Hello {s}. Now the time is {DateTime.Now}. Welcome!");
      //Console.WriteLine ($"Hello {s.ToUpper ()}, Welcome Always");
      //Console.WriteLine ("Hello {0}! Hope you are doing good! {1} ", Console.ReadLine (), "Welcome");
      //padding
      int n = 100;
      //Roght align paddig
      Console.WriteLine ($"Hi there is a 20 space along with {n,20}, so complete");
      //Left align padding
      Console.WriteLine ($"Hi there is a 20 space along with {n,-20}, so complete");
      //format Specifier
      Console.WriteLine ($"Hexadecimal of {n} is {n:X5}");
      Console.WriteLine ($"Decimal of {n} is {n:D}");
      Console.WriteLine ($"Binary of {n} is {n:B}");
      DateTime dt = DateTime.Now;
      Console.WriteLine ($"Hello. Now the ISO stadard date is {dt.Year}/{dt.Month}/{dt.Day}. Time is {dt.Hour}: {dt.Minute}: {dt.Second} Welcome!");
      Console.WriteLine ($"Hello. Now the ISO stadard date is {dt.Year}/{dt.Month:D2}/{dt.Day:D2}. Time is {dt.Hour:D2}: {dt.Minute:D2}: {dt.Second:D3} Welcome!");
      Console.WriteLine ($"Hello. Now the ISO stadard date is {dt:yyyy-MM-dd}. Time is {dt: HH|mm|ss} Welcome!");
      bool weekend = (DateTime.Now.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday);
      Console.WriteLine (weekend);
      //getting a name from user
      string result = getName ();
      Console.WriteLine (result);

      string getName () {
         for (; ; ) {
            string name = Console.ReadLine ();
            if (isValid (name)) return name;
            else Console.WriteLine ("enter valid name");
         }
      }
      int num = getInt ("enter a Number");
      Console.WriteLine ($"The number is {num}");

      int getInt (string prompt) {
         for (; ; ) {
            Console.WriteLine (prompt);
            if (int.TryParse (Console.ReadLine (), out int result)) return result;
         }
      }

      bool isValid (string str) {
         for (int i = 0; i < str.Length; i++)
            if (str[i] != ' ' && !char.IsDigit (str[i])) return true;
         return false;
      }

      //int getInt (string prompt) {
      //   for (; ; ) {
      //      Console.Write (prompt);
      //      string value = Console.ReadLine ();
      //      try {
      //         return int.Parse (value);
      //      } catch {
      //         Console.WriteLine ("not a number");
      //      }
      //   }
      //}
      //to genearte a random number from 1 to 100
   }
}