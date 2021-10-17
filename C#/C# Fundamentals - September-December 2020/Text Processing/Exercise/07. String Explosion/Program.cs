using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> field = Console.ReadLine().ToCharArray().ToList();
            for (int i = 0; i < field.Count; i++)
            {
                if(field[i] == '>')
                {
                    int strenght = field[i + 1]-'0';
                    int current = i + 1;
                    while (strenght>0 && current < field.Count)
                    {                        
                        if(field[current] != '>')
                        {
                            field.RemoveAt(current);
                            current--;
                            strenght--;
                        }
                        else
                        {
                            strenght += field[current + 1]-'0';
                        }
                        current++;
                    }
                    i = current-1;
                }
            }
            Console.WriteLine(string.Join("", field));
        }
    }
}
