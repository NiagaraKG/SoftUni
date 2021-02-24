using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double cost = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double sum = 0.00;
            for (int i = 1; i <= months; i++)
            {
                if(i%2==1 && i != 1)
                { sum = sum * 0.84; }
                if(i % 4 == 0) { sum = sum * 1.25; }
                sum += cost * 0.25;
            }
            double diff = Math.Abs(sum - cost);
            if(sum >= cost)
            { Console.WriteLine($"Bravo! You can go to Disneyland and you will have {diff:F2}lv. for souvenirs.");}
            else { Console.WriteLine($"Sorry. You need {diff:F2}lv. more."); }
        }
    }
}
