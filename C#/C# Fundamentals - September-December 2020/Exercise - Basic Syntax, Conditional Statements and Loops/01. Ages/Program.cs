using System;

namespace _01._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string result;
            if(age < 3) { result = "baby"; }
            else if (age < 14) { result = "child"; }
            else if (age < 20) { result = "teenager"; }
            else if (age < 66) { result = "adult"; }
            else { result = "elder"; }
            Console.WriteLine(result);
        }
    }
}
