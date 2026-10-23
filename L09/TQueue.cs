using System;
using System.Collections.Generic;
using System.Text;

namespace L09 {
   class TQueue<T> {
      public void TEnqueue (T a) {
         if (mUsed == mQueue.Length) { //if the elements to add exceeds this will excute by allocating double the previous space
            int newSize = mQueue.Length == 0 ? 4 : 2 * mQueue.Length;
            T[] tmp = new T[newSize];
            for (int i = 0; i < mUsed; i++) // copy iold array to new array
               tmp[i] = mQueue[i];
            mQueue = tmp;
         }
         mQueue[mUsed++] = a;
      }
      public T TDequeue () {
         if (mUsed == 0) throw new Exception ("Queue Empty");
         T tOut = mQueue[0]; // storing the fiorts elemnt
         mUsed--;
         T[] tmp = new T[mUsed]; // as dequeue the elemrnt lost the storage
         for (int i = 0; i < mUsed; i++) // loops also will decrease by 1
            tmp[i] = mQueue[i + 1]; // copies the elements
         mQueue = tmp; //agai back to dequeue
         return tOut;
      }
      public T TPeek () {
         if (mUsed == 0) throw new Exception ("Queue Empty");
         return mQueue[0];
      }
      public int TCount () => mUsed;
      public void TClear () {
         mUsed = 0;
         mQueue = new T[4];
      }
      public bool TIsEmpty () => mUsed == 0;
      T[] mQueue = new T[4];
      int mUsed;
   }
}
