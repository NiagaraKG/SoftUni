using System;
namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (String.IsNullOrEmpty(data[0]) || int.Parse(data[1]) < 0 || String.IsNullOrEmpty(data[2]))
                { Console.WriteLine("Invalid input!"); }
                else
                {
                    switch (input)
                    {
                        case "Dog": 
                            Dog d = new Dog(data[0], int.Parse(data[1]), data[2]);
                            Console.WriteLine("Dog");
                            Console.WriteLine($"{d.Name} {d.Age} {d.Gender}");
                            Console.WriteLine(d.ProduceSound());
                            break;
                        case "Frog": 
                            Frog f = new Frog(data[0], int.Parse(data[1]), data[2]);
                            Console.WriteLine("Frog");
                            Console.WriteLine($"{f.Name} {f.Age} {f.Gender}");
                            Console.WriteLine(f.ProduceSound());
                            break;
                        case "Cat": 
                            Cat c = new Cat(data[0], int.Parse(data[1]), data[2]);
                            Console.WriteLine("Cat");
                            Console.WriteLine($"{c.Name} {c.Age} {c.Gender}");
                            Console.WriteLine(c.ProduceSound());
                            break;
                        case "Tomcat": 
                            Tomcat t = new Tomcat(data[0], int.Parse(data[1]));
                            Console.WriteLine("Tomcat");
                            Console.WriteLine($"{t.Name} {t.Age} {t.Gender}");
                            Console.WriteLine(t.ProduceSound());
                            break;
                        case "Kitten":
                            Kitten k = new Kitten(data[0], int.Parse(data[1]));
                            Console.WriteLine("Kitten");
                            Console.WriteLine($"{k.Name} {k.Age} {k.Gender}");
                            Console.WriteLine(k.ProduceSound());
                            break;
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
