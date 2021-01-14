using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Stack<string> expression = new Stack<string>(input.Reverse());
            int result = 0;
            while(expression.Count > 1)
            {
                int operand1 = int.Parse(expression.Pop());
                string Operator = expression.Pop();
                int operand2 = int.Parse(expression.Pop());
                if(Operator == "+") { result = operand1 + operand2; }
                else { result = operand1 - operand2; }
                expression.Push(result.ToString());
            }
            Console.WriteLine(expression.Pop());
        }
    }
}
