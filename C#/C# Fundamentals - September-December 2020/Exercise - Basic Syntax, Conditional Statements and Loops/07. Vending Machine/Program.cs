using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            double change = 0;
            input = Console.ReadLine();
            while (input != "Start")
            {                
                if(input != "2" && input != "1" && input != "0.5" && input != "0.2" && input != "0.1")
                { Console.WriteLine($"Cannot accept {input}"); }
                else { change += double.Parse(input); }
                input = Console.ReadLine();
            }
            
            while (input != "End")
            {
                input = Console.ReadLine();
                if(input == "End") { break; }
                switch (input)
                {
                    case "Nuts":
                        if(change >= 2) 
                        {
                            Console.WriteLine("Purchased nuts");
                            change -= 2;
                            break; 
                        }
                        else 
                        { 
                            Console.WriteLine("Sorry, not enough money");
                            input = "End";
                            break; 
                        }
                    case "Water":
                        if(change >= 0.7)
                        {
                            Console.WriteLine("Purchased water");
                            change -= 0.7;
                            break; 
                        }
                        else 
                        { 
                            Console.WriteLine("Sorry, not enough money");
                            input = "End";
                            break; 
                        }
                    case "Crisps":
                        if(change >= 1.5) 
                        { 
                            Console.WriteLine("Purchased crisps");
                            change -= 1.5;
                            break; 
                        }
                        else 
                        { 
                            Console.WriteLine("Sorry, not enough money");
                            input = "End";
                            break; 
                        }
                    case "Soda":
                        if(change >= 0.8) 
                        {
                            Console.WriteLine("Purchased soda");
                            change -= 0.8;
                            break; 
                        }
                        else 
                        { 
                            Console.WriteLine("Sorry, not enough money");
                            input = "End";
                            break; 
                        }
                    case "Coke":
                        if(change >= 1) 
                        {
                            Console.WriteLine("Purchased coke");
                            change -= 1;
                            break; 
                        }
                        else 
                        { 
                            Console.WriteLine("Sorry, not enough money");
                            input = "End";
                            break; 
                        }
                    default: Console.WriteLine("Invalid product"); break;
                }
            }
            Console.WriteLine($"Change: {change:F2}");
        }
    }
}
