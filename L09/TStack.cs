using System;
using System.Collections.Generic;
using System.Text;

namespace L09 {
   class TStack<T> {
      public void TPush (T a) {

         if (mUsed == mStack.Length) {
            var tmp = new T[mUsed * 2];
            for (int i = 0; i < mUsed; i++) {
               tmp[i] = mStack[i];
            }
            mStack = tmp;
         }
         mStack[mUsed++] = a;
      }
      public T TPop () {
         if (mUsed == 0) throw new Exception ("Stack Empty");
         return mStack[--mUsed];
      }
      public T TPeek () {
         T a = TPop (); TPush (a); return a;
      }
      public bool IsEmpty => mUsed == 0;
      int mUsed;
      T[] mStack = new T[4];
   }


}
