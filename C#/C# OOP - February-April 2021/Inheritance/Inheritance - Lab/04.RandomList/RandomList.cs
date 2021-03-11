using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        public string RandomString()
        {
            Random r = new Random();
            int index = r.Next(this.Count);
            string toRemove = this[index];
            this.RemoveAt(index);
            return toRemove;
        }
    }
}
