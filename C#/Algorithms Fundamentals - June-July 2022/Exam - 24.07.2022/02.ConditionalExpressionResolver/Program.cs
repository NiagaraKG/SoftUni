using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            line = string.Join("", line.Split());
            Resolve(line);
        }

        private static void Resolve(string line)
        {
            int innerOperatorStart = line.LastIndexOfAny(new char[] { 't', 'f' });
            if (innerOperatorStart == 0)
            {
                if (line[innerOperatorStart] == 't') 
                {
                    Console.WriteLine(line[2]);
                    return; 
                }
                Console.WriteLine(line[4]);
                return;
            }
            string result;
            if (line[innerOperatorStart] == 't')
            {
                result = line[innerOperatorStart+2].ToString();
                
            }
            else { result = line[innerOperatorStart+4].ToString(); }
            line = line.Remove(innerOperatorStart, 5);
            line = line.Insert(innerOperatorStart, result);            
            Resolve(line);
        }
    }
}