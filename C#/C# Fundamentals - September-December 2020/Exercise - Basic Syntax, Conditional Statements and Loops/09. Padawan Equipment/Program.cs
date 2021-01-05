using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int students;
            double budget, lightsabre, robe, belt, cost = 0;
            budget = double.Parse(Console.ReadLine());
            students = int.Parse(Console.ReadLine());
            lightsabre = double.Parse(Console.ReadLine());
            robe = double.Parse(Console.ReadLine());
            belt = double.Parse(Console.ReadLine());
            cost += robe * students;
            cost += belt * (students - (students / 6));
            cost += lightsabre * Math.Ceiling(students * 1.1);
            if(cost <= budget) 
            { Console.WriteLine($"The money is enough - it would cost {cost:F2}lv."); }
            else
            { Console.WriteLine($"Ivan Cho will need {(cost - budget):F2}lv more."); }
        }
    }
}
