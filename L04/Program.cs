
namespace L04;

class Program {
   static void Main (string[] args) {
      char[] seed = new[] { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
      Console.WriteLine ("List");
      List<char> list = new ();
      foreach (char ch in seed) {
         list.Add (ch);
         Console.Write ($"{ch} ");
      }
      Stack<char> st = new ();
      Console.WriteLine ("\n\nStack");
      foreach (char ch in list) st.Push (ch);
      while (st.Count > 0)
         Console.Write ($"{st.Pop ()} ");
      Console.WriteLine ("\n\nQueue");
      Queue<char> qu = new ();
      foreach (char ch in list) qu.Enqueue (ch);
      while (qu.Count > 0)
         Console.Write ($"{qu.Dequeue ()} ");
      Console.WriteLine ($"\n\nTuples");
      //declaring and initialize a tuple
      (int p, int q) = (6, 8);
      var (a, b, c) = (6, 4, "true");
      (a, b) = (b, a);
      (q, p) = (p, q);

      // (a, b) = (a < b) ? (a, b) : (b, a);
      Console.WriteLine ($"The Order is: {a}, {b}, {c}");

      //in case not using tuple
      int x = 5, y = 1;
      int nx = (x < y) ? x : y; //if x is smaller same order
      int ny = (x > y) ? x : y; //if y is larger
      Console.WriteLine ($"The Order is: {nx}, {ny}");
      /*
           //A03
           var words = File.ReadAllLines ("C:/Users/srinivasanve/Downloads/words.txt");
           string nseed = "UXALTNE";
           List<string> Result = new ();

           //.Where is predicate -> if /else
           //.Select is transformer --> str->str,score and pangrams
           int count = 0;
           foreach (var data in words.Where (ValidString)
                                      .Select (GetScore)
                                      .OrderByDescending (a => a.Score)) {
              if (data.IsPangram) Console.ForegroundColor = ConsoleColor.Green;
              Console.WriteLine ($"{data.Score,3} {data.Word}");
              Console.ResetColor ();
              count += data.Score;
           }
           Console.WriteLine ($"----\n{count,3} total");

           bool IsSeed (string str) {
              return str.Distinct ().Count () == 7 && str.All (ch => ch is >= 'A' and <= 'Z');
           }

           //create valid method--> len>3, must contain the firt letter, and only contain those 7 letters
           bool ValidString (string str) => str.Length >= 4 && str.Contains (nseed[0]) && str.All (nseed.Contains);
           /*
                 bool ValidString (string str) {
                    if (str.Length < 4) return false;
                    bool found = false;
                    foreach (char c in str)
                       if (c == nseed[0]) { found = true; break; }
                    if (!found) return false;
                    foreach (char ch in str) {
                       found = false;
                       foreach (char ns in nseed)
                          if (ch == ns) { found = true; break; }
                       if (!found) return false;
                    }
                    return true;
                 }

           (String Word, int Score, bool IsPangram) GetScore (string str) {
              int score = 0;
              bool pangram = nseed.All (str.Contains);
              score = (str.Length > 4 ? str.Length : 1) + (pangram ? 7 : 0);
              return (str, score, pangram);
           }
      */

      /*
            Dictionary<char, int> fTable = new Dictionary<char, int> () {
               {'A', 0},{'B', 0},{'C', 0},{'D', 0},{'E', 0},{'F', 0},{'G', 0},
               {'H', 0},{'I', 0},{'J', 0},{'K', 0},{'L', 0},{'M', 0},{'N', 0},
               {'O', 0},{'P', 0},{'Q', 0},{'R', 0},{'S', 0},{'T', 0},
               {'U', 0},{'V', 0},{'W', 0},{'X', 0},{'Y', 0},{'Z', 0}
            };
            string[] word = File.ReadAllLines ("C:/Users/srinivasanve/Downloads/words.txt");
            foreach (string str in word)
               foreach (char ch in str)
                  if (fTable.ContainsKey (ch))
                     fTable[ch] += 1;
            foreach (var dict in fTable.OrderByDescending (a => a.Value))
               Console.WriteLine ($"{dict.Key} {dict.Value} ");
         */
   }
}
