using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int loses = int.Parse(Console.ReadLine());            
            double headset = double.Parse(Console.ReadLine());
            double mouse = double.Parse(Console.ReadLine());
            double keyboard = double.Parse(Console.ReadLine());
            double display = double.Parse(Console.ReadLine());
            double total = headset * (loses / 2) + mouse * (loses / 3) + keyboard * (loses / 6) + display * (loses/ 12);
            Console.WriteLine($"Rage expenses: {total:F2} lv.");
        }
    }
}
