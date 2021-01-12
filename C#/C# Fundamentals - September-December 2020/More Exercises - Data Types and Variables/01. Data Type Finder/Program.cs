using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                int i;
                if (int.TryParse(input, out i))
                { Console.WriteLine($"{input} is integer type"); }                                
                else
                {
                    double d;
                    if (double.TryParse(input, out d))
                    { Console.WriteLine($"{input} is floating point type"); }
                    else
                    {
                        bool b;
                        if (bool.TryParse(input, out b))
                        { Console.WriteLine($"{input} is boolean type"); }
                        else
                        {
                            if(input.Length == 1) { Console.WriteLine($"{input} is character type"); }
                            else { Console.WriteLine($"{input} is string type"); }
                        }
                    }                    
                }
                input = Console.ReadLine();
            }
        }
    }
}
