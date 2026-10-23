namespace L08;
/// <summary>
/// namespace L08;
/// Program to evalate the input expression in console window
/// Returns the evaluated expression in the same console window
/// uses class evaluator and method evaluate
/// </summary>
class Program {
   static void Main (string[] args) {
      var eval = new Evaluator ();
      for (; ; ) {
         Console.Write (">");
         string input = Console.ReadLine ().Trim ().ToLower (); // get input from the console
         if (input == "") break;
         try {
            double result = eval.Evaluate (input); // class object eval calling Evaluate to process
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine (result);
         } catch (Exception e) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine (e.Message);
         }
         Console.ResetColor ();
      }
   }
}
