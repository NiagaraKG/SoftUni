using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> stones;
        public Lake(params T[] input) { this.stones = new List<T>(input); }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i+=2)
            {
                yield return stones[i];
            }
            int index = stones.Count - 1;
            if(index%2==0) { index--; }
            for (int i = index; i >=0; i-=2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
    }
}
