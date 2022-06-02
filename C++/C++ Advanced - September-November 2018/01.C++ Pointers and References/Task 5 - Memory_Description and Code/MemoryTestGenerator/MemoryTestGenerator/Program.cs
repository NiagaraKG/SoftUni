using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomExtensions;

namespace MemoryTestGenerator
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            GenerateTest(testName: "test.001", companiesCount: 2, minEmployees: 3, maxEmployees: 3);
            GenerateTest(testName: "test.002", companiesCount: 1, minEmployees: 3, maxEmployees: 3);
            GenerateTest(testName: "test.003", companiesCount: 1, minEmployees: 1, maxEmployees: 1);
            GenerateTest(testName: "test.004", companiesCount: 1, minEmployees: 0, maxEmployees: 0);
            GenerateTest(testName: "test.005", companiesCount: 10, minEmployees: 3, maxEmployees: 9);

            GenerateTest(testName: "test.006", companiesCount: 20, minEmployees: 3, maxEmployees: 50);
            GenerateTest(testName: "test.007", companiesCount: 10, minEmployees: 3, maxEmployees: 3);
            GenerateTest(testName: "test.008", companiesCount: 1, minEmployees: 10, maxEmployees: 10);
            GenerateTest(testName: "test.009", companiesCount: 10, minEmployees: 10, maxEmployees: 100);
            GenerateTest(testName: "test.010", companiesCount: 100, minEmployees: 255, maxEmployees: 255);
        }

        class Company
        {
            public byte Id { get; }
            public string Name { get; }
            public List<Pair<char>> EmployeeInitials { get; }

            public Company(byte id, string name, List<Pair<char>> employeeInitials)
            {
                this.Id = id;
                this.Name = name;
                this.EmployeeInitials = employeeInitials;
            }

            public override string ToString()
            {
                return Id + " " + Name + " (" + string.Join(",", EmployeeInitials.Select(p => p.First + "." + p.Second + ".")) + ")";
            }

            public byte[] ToByteArray()
            {
                int idSize = 1;
                int nameSize = (Name.Length + 1);
                int employeeInitialsSize = (1 + EmployeeInitials.Count * 2);
                int size = idSize + nameSize + employeeInitialsSize;

                byte[] bytes = new byte[size];

                int i = 0;

                bytes[i++] = Id;

                foreach (char letter in Name)
                {
                    bytes[i++] = (byte)letter;
                }
                bytes[i++] = 0; // null terminator

                bytes[i++] = (byte)EmployeeInitials.Count;
                foreach (var initialsPair in EmployeeInitials)
                {
                    bytes[i++] = (byte)initialsPair.First;
                    bytes[i++] = (byte)initialsPair.Second;
                }

                return bytes;
            }
        }

        private static void GenerateTest(string testName, int companiesCount, int minEmployees, int maxEmployees)
        {
            HashSet<byte> ids = r.NextUniqueN(companiesCount, () => (byte)r.Next(0, 256));

            List<Company> companies = new List<Company>();
            foreach (var id in ids)
            {
                List<Pair<char>> employeeInitials;
                if (maxEmployees > 0)
                {
                    employeeInitials = r.NextUniqueN(r.Next(minEmployees, maxEmployees + 1), () => new Pair<char>(r.NextLetter(true), r.NextLetter(true))).ToList();
                }
                else
                {
                    employeeInitials = new List<Pair<char>>();
                }

                companies.Add(new Company(id, r.NextWord(r.Next(1, 6 + 1), 0), employeeInitials));
            }

            System.IO.File.WriteAllText(testName + ".in.txt", string.Join(System.Environment.NewLine, companies.Select(c => string.Join(" ", c.ToByteArray().ToList()))) 
                + System.Environment.NewLine + "end" + System.Environment.NewLine);
            System.IO.File.WriteAllText(testName + ".out.txt", string.Join(System.Environment.NewLine, companies.Select(c => string.Join(" ", c.ToString()))));
        }
    }
}

namespace RandomExtensions
{
    class Pair<T>
    {
        public T First { get; set; }
        public T Second { get; set; }
        public Pair(T first, T second)
        {
            this.First = first;
            this.Second = second;
        }
    }

    static class RandomExtensions
    {
        const string Vowels = "aeiouwy";
        const string Consonants = "bcdfghjklmnpqrstvwxz";

        public static char NextLetter(this Random r, bool capital)
        {
            return (char)(capital ? r.Next('A', 'Z' + 1) : r.Next('a', 'z' + 1));
        }

        public static HashSet<T> NextUniqueN<T>(this Random r, int count, Func<T> generator)
        {
            HashSet<T> unique = new HashSet<T>();

            while (unique.Count < count)
            {
                unique.Add(generator.Invoke());
            }

            return unique;
        }

        public static string NextWord(this Random r, int length, double capitalsChance)
        {
            StringBuilder word = new StringBuilder();

            while (word.Length < length)
            {
                string source;
                if (word.Length == 0)
                {
                    source = r.NextChance(0.5) ? Vowels : Consonants;
                }
                else if (Vowels.Contains(word[word.Length - 1]))
                {
                    source = r.NextChance(0.8) ? Consonants : Vowels;
                }
                else
                {
                    source = r.NextChance(0.8) ? Vowels : Consonants;
                }

                word.Append(source[r.Next(0, source.Length)]);
            }

            for (int i = 0; i < word.Length; i++)
            {
                word[i] = r.NextChance(capitalsChance) ? char.ToUpper(word[i]) : word[i];
            }

            return word.ToString();
        }

        public static bool NextChance(this Random r, double probability)
        {
            // NOTE: 0 probability is always false (min NextDouble() is 0, 0 < 0 is false) and 1 probability is always true (NextDouble() always returns less than 1)
            return r.NextDouble() < probability;
        }

        public static List<int> NextIncreasingOrEqualInRange(this Random r, int length, Pair<int> rangeInclusive)
        {
            List<int> values = new List<int>();
            while (values.Count < length)
            {
                values.Add(r.Next(values.Count > 0 ? values[values.Count - 1] : rangeInclusive.First, rangeInclusive.Second + 1));
            }

            return new List<int>(values);
        }

        public static List<int> NextStrictlyIncreasingInRange(this Random r, int length, Pair<int> rangeInclusive)
        {
            int rangeElementsCount = (rangeInclusive.Second - rangeInclusive.First) + 1;
            if (rangeElementsCount < length)
            {
                throw new ArgumentException("rangeInclusive does not contain enough values to generate required length");
            }

            SortedSet<int> values = new SortedSet<int>();
            while (values.Count < length)
            {
                values.Add(r.Next(rangeInclusive.First, rangeInclusive.Second + 1));
            }

            return new List<int>(values);
        }

        public static void NextShuffle<T>(this Random r, List<T> list)
        {
            for (int repeats = 0; repeats < 10; repeats++)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int otherInd = r.Next(0, list.Count);
                    var swap = list[i];
                    list[i] = list[otherInd];
                    list[otherInd] = swap;
                }
            }
        }

        public static int NextIndex<T>(this Random r, ICollection<T> range)
        {
            return r.Next(0, range.Count);
        }

        public static T NextFrom<T>(this Random r, List<T> from)
        {
            return from[NextIndex(r, from)];
        }

        public static List<int> NextIntegersFrom(this Random r, int count, List<int> from)
        {
            List<int> integers = new List<int>();

            while (integers.Count < count)
            {
                integers.Add(NextFrom(r, from));
            }

            return integers;
        }

        public static List<int> NextIntegers(this Random r, int count)
        {
            return NextIntegersExcluding(r, count, new HashSet<int>());
        }

        public static List<int> NextIntegersExcluding(this Random r, int count, HashSet<int> excluded)
        {
            List<int> integers = new List<int>();

            while (integers.Count < count)
            {
                integers.Add(NextExcluding(r, excluded));
            }

            return integers;
        }

        public static int NextExcluding(this Random r, HashSet<int> excluded)
        {
            int value = r.Next();
            while (excluded.Contains(value))
            {
                value = r.Next();
            }

            return value;
        }
    }
}
