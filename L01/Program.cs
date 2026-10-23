class Program {
   static void Main (string[] args) {
      Console.WriteLine ("Hello, World!");
      Enumerable.Range (1, 10)
      .Where (i => i % 2 == 0)
      .Select (i => i * i)
      .ToList ()
      .ForEach (Console.WriteLine);

      /*
      for (int i = 1; i <= 10; i++)
         if (isEven (i))
            Console.WriteLine (Square (i));
         else
            Console.WriteLine ("Odd");
      bool isEven (int input) => input % 2 == 0;
      */

      //bool isEven(int input) {
      ////   return input % 2 == 0;
      //}
      //bool isEven (int input) {
      //   if (input % 2 == 0)
      //      return true;
      //   else
      //      return false;
      //}

      long bigInt = 9223372036854775807; // Max long
      double bigDouble = 1.79769313486232308; // Large double
      Console.WriteLine ($"Long: {bigInt}");
      Console.WriteLine ($"Double: {bigDouble}");
      // Implicit conversion from long to double
      double converted = bigInt;
      Console.WriteLine ($"Converted long to double: {converted}");
      // Explicit conversion from double to long
      long backToLong = (long)12345.6789;
      Console.WriteLine ($"Double to long: {backToLong}");
   }
   static double Square (int input) {
      return input * input;
   }
}
