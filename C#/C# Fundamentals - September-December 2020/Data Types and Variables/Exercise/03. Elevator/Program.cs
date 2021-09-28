using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;
            while(persons > 0)
            {
                courses++;
                persons -= capacity;
            }
            Console.WriteLine(courses);
        }
    }
}
