
namespace L05;

class Program {
   static void Main () {
      /*
      var sw = Stopwatch.StartNew ();
      Dictionary<char, int> freq = new ();

      //string[] words = File.ReadAllLines ("C://Users//srinivasanve//Downloads//words.txt");
      foreach (char ch in File.ReadAllText ("C://Users//srinivasanve//Downloads//words.txt"))
         if (ch >= 'A' && ch <= 'Z') {
            if (freq.ContainsKey (ch))
               freq[ch] += 1;
            else
               freq[ch] = 1;
         }
      foreach (var dict in freq.OrderByDescending (a => a.Value).Take (7))
         Console.WriteLine (dict);
      sw.Stop ();
      Console.WriteLine (sw.Elapsed.TotalMilliseconds);
      Console.WriteLine (sw.Elapsed.TotalHours);

      //two tier compilation-> jit compiler
      int[] alpha = new int[26];
      foreach (char ch in File.ReadAllText ("C://Users//srinivasanve//Downloads//words.txt"))
         if(ch is >= 'A'and <='Z')alpha[ch - 'A'] ++;
      Dictionary<char, int> freq = new ();
      for (char c = 'A'; c <= 'Z'; c++)
         freq[c] = alpha[c - 'A'];
      foreach (var dict in freq.OrderByDescending (a => a.Value).Take (7))
         Console.WriteLine (dict);
      */

      Dictionary<char, int> freq = new ();
      for (char c = 'A'; c <= 'Z'; c++) freq[c] = 0;
      foreach (char ch in File.ReadAllText ("C://Users//srinivasanve//Downloads//words.txt"))
         if (ch >= 'A' && ch <= 'Z')
            freq[ch]++;
      foreach (var dict in freq.OrderByDescending (a => a.Value).Take (7))
         Console.WriteLine (dict);

      //Hashcode is unite identifier--magic
      int a = 10;
      var c1 = Math.PI;
      Console.WriteLine (a.GetHashCode ());
      Console.WriteLine (c1.GetHashCode ());
      int[] x = { 3, 5, 4, 3, 5, 6, 7 };
      Console.WriteLine (x[0].Equals (x[3]));
      foreach (int i in x.Distinct ().OrderByDescending (a => a))
         Console.Write ($"{i} ");
      HashSet<int> set = new ();
      foreach (int n in x) {
         //if (set.Contains (n)) continue;
         //set.Add (n);
         //Console.WriteLine ($"The value {n} is added ");
         if (set.Add (n))
            Console.WriteLine ($"The value {n} is added ");
      }
      int[] bad = { 3, 5 };
      //foreach (int n in x.Except (bad))
      //   Console.WriteLine (n);
      //foreach (int n in x)
      //   if (!bad.Contains (n))
      //      Console.WriteLine (n);// O(mxn)

      //using hasttable
      HashSet<int> hbad = new ();
      foreach (int n in x)
         if (hbad.Add (n)) Console.WriteLine ($"{n} is added"); //O(m+n)
      int res = Factorial (4);
      Console.WriteLine (res);
      int Factorial (int num) {
         if (num <= 0) return 1;
         return num * Factorial (num - 1);

         //// Initialize a dictionary => keys: upper case alphabets, values: 0
         //Dictionary<char, int> frequencyTable = new ();
         //for (char c = 'A'; c <= 'Z'; c++)
         //   frequencyTable[c] = 0;
         //// Transforms lower case alphabets to uppercase and counts each character and update values
         //foreach (var ch in File.ReadAllText ("C://Users//srinivasanve//Downloads//words.txt")
         //         .Where(a=>char.IsLetter(a)).Select (a => char.ToUpper (a)))
         //   if (frequencyTable.ContainsKey (ch))
         //      frequencyTable[ch]++;
         //// To display first 7 letters uses as a seed list for spelling bee.
         //Console.Write ("The SeedList is: ");
         //foreach (var item in frequencyTable.OrderByDescending (a => a.Value).Take (7))
         //   Console.Write (item.Key);
      }
   }
}
