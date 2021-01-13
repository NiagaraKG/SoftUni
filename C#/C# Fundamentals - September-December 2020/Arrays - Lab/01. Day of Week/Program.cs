using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "Invalid day!", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int i = int.Parse(Console.ReadLine());
            if(i < 1 || i > 7) { i = 0; }
            Console.WriteLine(days[i]);
        }
    }
}
