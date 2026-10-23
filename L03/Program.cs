namespace L03;

class Program {
   static void Main (string[] args) {
      /*
            //get the mode[E,M,H]
            //set the range and think of a secret number
            //get into loop
            // -get a guess from use
            // -check if the guess is Low/Eaxact/High and respond appropriately

            var mode = GetMode ();
            Console.WriteLine (mode);
            int max = GetMax (mode);
            int secret = new Random ().Next (1, max + 1);
            for (int i = 1; ; i++) {
               int guess = ReadInt (">");
               var result = CheckGuess (secret, guess);
               if (result == Guess.Exact) {
                  Console.WriteLine ($"you guessed in {i} tries");
                  break;
               }
               Console.WriteLine ($"Your gues is too {result}");
            }

            int ReadInt (string prompt) {
               for (; ; ) {
                  Console.WriteLine (prompt);
                  if (int.TryParse (Console.ReadLine (), out int result)) return result;
                  Console.WriteLine ("Invalid");
               }
            }

            Guess CheckGuess (int secret, int guess) {
               if (secret == guess) return Guess.Exact;
               if (guess > secret) return Guess.High;
               return Guess.Low;
            }

            Mode GetMode () {
               Console.WriteLine ("Choose: [E]asy, [M]edium , [H]ard");
               for (; ; ) {
                  var key = Console.ReadKey (true).Key;
                  switch (key) {
                     case ConsoleKey.H: return Mode.Hard;
                     case ConsoleKey.M: return Mode.Medium;
                     case ConsoleKey.E: return Mode.Easy;
                     default: break;
                  }
                  if (key == ConsoleKey.E) return Mode.Easy;
                  if (key == ConsoleKey.M) return Mode.Medium;
                  if (key == ConsoleKey.H) return Mode.Hard;*//*
               }
            }

            //set the range and think of a secret number
            int GetMax (Mode mode) {
               switch (mode) {
                  case Mode.Easy: return 10;
                  case Mode.Medium: return 100;
                  default: return 1000;
               }
               if (mode == Mode.Easy) return 10;
               if (mode == Mode.Medium) return 100;
               return 1000;  //compiler not satisfy with the not all code path returns a value
            }
         }

         enum Mode { Easy, Medium, Hard };
         enum Guess { Exact, Low, High };
      }*/

      //Arrays: Value typr & reference type
      int a = 10;
      int b = a;
      a = 20;
      Console.WriteLine (a);
      Console.WriteLine (b);
      int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
      int[] arr2 = new int[5];
      for (int i = 0; i < arr1.Length; i++)
         arr2[i] = arr1[i];
      arr1[4] = 20;
      Console.WriteLine (arr1[4]);
      Console.WriteLine (arr2[4]);

      //value types
      int x = 100;
      F1 (x);
      Console.WriteLine (x);

      void F1 (int x) {
         x = 200;
      }

      //reference type
      int[] arr3 = new[] { 1, 2, 3 };
      F2 (arr3);
      foreach (int i in arr3)
         Console.WriteLine (i);

      void F2 (int[] arr) {
         arr[1] = 200;
      }
      /*
            //Reading a file
            string[] words = File.ReadAllLines ("C:/Users/srinivasanve/Downloads/words.txt");

            //->adding words that contains "U" to the list.
            List<string> validStrings = new List<string> ();
            List<string> deleteStrings = new List<string> ();

            //each word must contain a letter "U"
            foreach (string i in words)
               if (i.Contains ("U") && i.Length > 3)
                  validStrings.Add (i);

            //adding the invalid words that cotain other than seven letters
            foreach (string s in validStrings)
               foreach (char c in s)
                  if (c == 'U' || c == 'X' || c == 'A' || c == 'L' || c == 'T' || c == 'N' || c == 'E')
                     continue;
                  else
                     deleteStrings.Add (s);

            //Deleting InValid words
            foreach (string st in deleteStrings)
               validStrings.Remove (st);

            //Console Layout
            int total = 0;
            foreach (string s in validStrings.OrderByDescending (s => Score (s))) {
               Console.WriteLine ($"{Score (s),3}. {s}");
               total += Score (s);
            }
            Console.WriteLine ($"----\n{total} total");

            //Score checking
            int Score (string s) {
               if (s.Length == 4)
                  return 1;
               else if (s.Contains ("U") && s.Contains ("X") && s.Contains ("A") && s.Contains ("L") && s.Contains ("T") && s.Contains ("N") && s.Contains ("E"))
                  return 7 + s.Length;
               else
                  return s.Length;
            }

            //LET USER THINK OF A RANDOM NUMBER
            //THE MACHINE SHOULD GUESS WHAT IS THE NUMBER

            int min = 0;
            int max = 127;
            Console.WriteLine ("Answer [Y]es or [N]o for the following");
            string result = "";
            SecretCheck (min, max);

            void SecretCheck (int l_min, int l_max) {
               for (int i = 7; i > 0; i--) {
                  int l_mid = (l_min + l_max + 1) / 2;
                  Console.Write ($"Is the number less than {l_mid}: ");
                  var option = Console.ReadKey (true).Key;
                  if (option == ConsoleKey.Y) {
                     Console.WriteLine ("Yes");
                     l_max = l_mid;
                     result += "0";
                     //if (i == 1)
                     //   Console.WriteLine ($"{l_mid - 1} is your guess number");
                  }
                  if (option == ConsoleKey.N) {
                     Console.WriteLine ("No");
                     l_min = l_mid;
                     result += "1";
                     //if (i == 1)
                     //   Console.WriteLine ($"{l_mid} is your guess Number");
                  }
                  if (option != ConsoleKey.Y && option != ConsoleKey.N)
                     i++;
               }
            }
            Console.WriteLine ($"the answer: {Convert.ToInt32(result,2)}");
      */
   }
}
