using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while(command != "end")
            {
                string[] task = command.Split();                
                if(task[0] == "exchange")
                {
                    input = Exchange(input, int.Parse(task[1]));
                }
                else if(task[0] == "max" && task[1] == "even")
                {
                    FindMaxEven(input);
                }
                else if(task[0] == "max" && task[1] == "odd")
                {
                    FindMaxOdd(input);
                }
                else if(task[0] == "min" && task[1] == "even")
                {
                    FindMinEven(input);
                }
                else if(task[0] == "min" && task[1] == "odd")
                {
                    FindMinOdd(input);
                }
                else if(task[0] == "first" && task[2] == "even")
                {
                    FindFirstEven(input, int.Parse(task[1]));
                }
                else if(task[0] == "first" && task[2] == "odd")
                {
                    FindFirstOdd(input, int.Parse(task[1]));
                }
                else if(task[0] == "last" && task[2] == "even")
                {
                    FindLastEven(input, int.Parse(task[1]));
                }
                else if(task[0] == "last" && task[2] == "odd")
                {
                    FindLastOdd(input, int.Parse(task[1]));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[" + String.Join(", ",input) + "]");
        }

        static int[] Exchange(int[] input, int index)
        {
            if(index < 0 || index >= input.Length)
            {
                Console.WriteLine("Invalid index");
                return input;
            }
            string f = "", s = "";
            for (int i = 0; i <= index; i++)
            {
                f += input[i] + " ";
            }
            int[] first = f.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = index+1; i < input.Length; i++)
            {
                s += input[i] + " ";
            }
            int[] second = s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return second.Concat(first).ToArray();
        }
        static void FindFirstEven(int[] input, int count)
        {
            if (count > input.Length) { Console.WriteLine("Invalid count"); }
            else
            {
                
                int br = 0;
                string even = "[";
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        br++;
                    }
                }
                if (br < count)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            if (br > 1) { even += input[i] + ", "; br--; }
                            else if (br == 1) { even += input[i]; br--; }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            if (count > 1) { even += input[i] + ", "; count--; }
                            else if (count == 1) { even += input[i]; count--; }
                        }
                    }
                }
                even += "]";
                    Console.WriteLine(even);
                
            }
        }
        static void FindFirstOdd(int[] input, int count)
        {
            if (count > input.Length) { Console.WriteLine("Invalid count"); }
            else
            {

                int br = 0;
                string odd = "[";
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 1)
                    {
                        br++;
                    }
                }
                if (br < count)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] % 2 == 1)
                        {
                            if (br > 1) { odd += input[i] + ", "; br--; }
                            else if (br == 1) { odd += input[i]; br--; }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] % 2 == 1)
                        {
                            if (count > 1) { odd += input[i] + ", "; count--; }
                            else if (count == 1) { odd += input[i]; count--; }
                        }
                    }
                }
                odd += "]";
                    Console.WriteLine(odd);
                
            }
        }
        static void FindLastEven(int[] input, int count)
        {
            if (count > input.Length) { Console.WriteLine("Invalid count"); }
            else
            {

                int br = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        br++;
                    }
                }
                if (br < count)
                {
                    int[] even = new int[br];
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        if (input[i] % 2 == 0)
                        {
                            if (br >= 1) { even[br - 1] = input[i]; br--; }
                        }
                    }
                    Console.WriteLine("[" + String.Join(", ", even) + "]");
                }
                else
                {
                    int[] even = new int[count];
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        if (input[i] % 2 == 0)
                        {
                            if (count > 0) { even[count - 1] = input[i]; count--; }
                        }
                    }
                    Console.WriteLine("[" + String.Join(", ", even) + "]");
                }
            }
        }
        static void FindLastOdd(int[] input, int count)
        {
            if (count > input.Length) { Console.WriteLine("Invalid count"); }
            else
            {

                int br = 0;                
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 1)
                    {
                        br++;
                    }
                }
                if (br < count)
                {
                    int[] odd = new int[br];
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        if (input[i] % 2 == 1)
                        {
                            if (br >= 1) { odd[br-1] = input[i]; br--; }                            
                        }
                    }
                    Console.WriteLine("[" + String.Join(", ", odd) + "]");
                }
                else
                {
                    int[] odd = new int[count];
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        if (input[i] % 2 == 1)
                        {
                            if (count > 0) { odd[count-1] = input[i]; count--; }                            
                        }
                    }
                    Console.WriteLine("[" + String.Join(", ", odd) + "]");
                }
            }

        }
        static void FindMaxEven(int[] input)
        {
            int max = Int32.MinValue, index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] % 2 == 0)
                {
                    if(input[i] >= max)
                    {
                        max = input[i];
                        index = i;
                    }
                }
            }
            if(max == Int32.MinValue) { Console.WriteLine("No matches"); }
            else { Console.WriteLine(index); }
        }
        static void FindMaxOdd(int[] input)
        {
            int max = Int32.MinValue, index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] % 2 == 1)
                {
                    if(input[i] >= max)
                    {
                        max = input[i];
                        index = i;
                    }
                }
            }
            if(max == Int32.MinValue) { Console.WriteLine("No matches"); }
            else { Console.WriteLine(index); }
        }
        static void FindMinEven(int[] input)
        {
            int min = Int32.MaxValue, index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] % 2 == 0)
                {
                    if(input[i] <= min)
                    {
                        min = input[i];
                        index = i;
                    }
                }
            }
            if(min == Int32.MaxValue) { Console.WriteLine("No matches"); }
            else { Console.WriteLine(index); }
        }
        static void FindMinOdd(int[] input)
        {
            int min = Int32.MaxValue, index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] % 2 == 1)
                {
                    if(input[i] <= min)
                    {
                        min = input[i];
                        index = i;
                    }
                }
            }
            if(min == Int32.MaxValue) { Console.WriteLine("No matches"); }
            else { Console.WriteLine(index); }
        }
    }
}
