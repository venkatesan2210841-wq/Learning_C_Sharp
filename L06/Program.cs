namespace L06;

class Program {
   static void Main (string[] args) {
      Console.WriteLine ("Hello, World!");
      /*
       * stack--|vstatic variable space, parameters, local variables
       * stack fram ethat f(1,2) added last in first out principle
       * stack pointer
       * int a,b;
       *
       *
       * Heap--dynamic space|^
       *
       *
       * minimize the global value
       * static is more specific to datattype
       */

      //refernce type--> heap space 50*4= 200 bytes-->p points to the start of the address
      int[] p = new int[50];
      int[] q = p; //both allocates same space p and q points to same address , when modified p or q it modifies the other.///
      //other datatype other than aarrray should be passed.
      p = null; //only cut p pointing to the address
      q = null;

      /*
       * in c# the heap that contains memory allocations through which
       * the stack variable those contains references for the variables
       * that are reachable to the memory block is only utilized in heap
       *
       * there is a rediretion happens so each time garbage collector runs
       * there is no free space(holes) unreachable objects gets freeded up
       * memory allocation becomes O(1)
       * List<int> val=new()
       * for(;;){
       * val.Clear();
       * val.Add();}
      */

      //Initializing a class
      Rectangle r = new (10, 7);
      r.Length = 10;
      r.Breadth = 20;
      Console.WriteLine (r.print ());
      //or
      r.pLength = 50;
      r.pBreadth = 70;
      Console.WriteLine (r);
      r.pLength = -30;
      r.pBreadth = 20;
      Console.WriteLine (r.ToString ());
   }
}

//Introduction to class=> Fields + Method
class Rectangle {
   //Constructor
   public Rectangle (double l, double w) {
      Length = l; Breadth = w;
   }
   // Fields
   public double Length;
   public double Breadth;
   //properties
   public double pArea () => Length * Breadth;
   //to a higher scope use
   double _area;
   double _length;
   double _breadth;
   double _perimeter;
   public double pLength {
      get {
         return _length;
      }
      set {
         if (value < 0) throw new Exception ("NO Negative length");
         _length = value;
         _area = _length * _breadth;
         _perimeter = 2 * (_length + _breadth);
      }
   }
   public double pBreadth {
      get => _breadth;
      set {
         if (value < 0) throw new Exception ("NO Negative breadth");
         _breadth = value;
         _area = _length * _breadth;
         _perimeter = 2 * (_length + _breadth);
      }
   }

   //Methods
   public double mArea () => Length * Breadth;
   public double mPerimeter () => 2 * Length * Breadth;
   //thi is a place holder
   public string print () => $"Function call: {this.Length} X {this.Breadth}";
   //replace the behaviour of Tostring so replace with the method --OVERRIDE
   public override string ToString () => $"Override function:{pLength} X {pBreadth}";

   /* program to solve 8 queens game--> possibilities
    * using System.Text
    * Console.OutputEncoding = new UniCodeEncoding();
    * Console.WriteLine("\u250c\u2500\u2500\u2500\u252\u2500\u2500\u2500\u2510");
    * Console.WriteLine("\u2502\u2655\u2502   \u2502")
    * Console.WriteLine("\u2514\u2500\u2500\u2500\u2534\\u2500\u2500\u2500\u2518")
   */
}
