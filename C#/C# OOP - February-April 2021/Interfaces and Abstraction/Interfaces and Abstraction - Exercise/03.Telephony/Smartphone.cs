using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Call(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit)) 
                { throw new InvalidOperationException("Invalid number!"); }
            }
            Console.WriteLine($"Calling... {number}");
        }
        public void Browse(string site)
        {
            foreach (var c in site)
            {
                if (char.IsDigit(c)) 
                { throw new InvalidOperationException("Invalid URL!"); }
            }
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
