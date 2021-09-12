using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person P = new Person("Pesho", 20);
            Person G = new Person();
            G.Name = "Gosho"; G.Age = 18;
            Person S = new Person("Stamat", 43);
        }
    }
}
