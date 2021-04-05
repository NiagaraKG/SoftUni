using System;

namespace _03.Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Smartphone smart = new Smartphone();
            StationaryPhone stationary = new StationaryPhone();
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            foreach (var num in numbers)
            {
                try
                {
                    if (num.Length == 10) { smart.Call(num); }
                    else { stationary.Call(num); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            foreach (var site in sites)
            {
                try { smart.Browse(site); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}
