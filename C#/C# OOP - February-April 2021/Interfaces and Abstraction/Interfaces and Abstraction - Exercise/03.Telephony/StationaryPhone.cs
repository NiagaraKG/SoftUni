using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit)) { throw new InvalidOperationException("Invalid number!"); }
            }
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
