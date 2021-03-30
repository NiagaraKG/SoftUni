using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                Pizza p = new Pizza(input[1]);
                input = Console.ReadLine().Split();
                p.Dough = new Dough(input[1], input[2], int.Parse(input[3]));
                input = Console.ReadLine().Split();
                while (input[0] != "END")
                {
                    p.Add(new Topping(input[1], int.Parse(input[2])));
                    input = Console.ReadLine().Split();
                }
                Console.WriteLine(p);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
    }
}
