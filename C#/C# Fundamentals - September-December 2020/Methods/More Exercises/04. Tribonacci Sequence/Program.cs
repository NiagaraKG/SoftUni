using System;

namespace _04._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[n];
            sequence[0] = 1;
            if (n > 1)
            {
                sequence[1] = 1;
                if (n > 2)
                {
                    sequence[2] = 2;
                    if (n > 3)
                    {
                        for (int i = 3; i < n; i++)
                        {
                            sequence[i] = GetTribonacci(sequence, i);
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(" ", sequence));
        }
        
        static int GetTribonacci(int[] sequence, int i)
        {
            return (sequence[i - 1] + sequence[i - 2] + sequence[i - 3]) ;
        }

    }
}
