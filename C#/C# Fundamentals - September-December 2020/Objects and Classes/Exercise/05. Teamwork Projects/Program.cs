using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            List<Team> existing = new List<Team>();
            List<Team> disbanded = new List<Team>();
            for (int i = 0; i < n; i++)
            {
                string[] input = line.Split("-");                
                bool isTeam = existing.Select(x => x.Name).Contains(input[1]);
                bool isCreator = existing.Select(x => x.Creator).Contains(input[0]);
                if(isTeam) { Console.WriteLine($"Team {input[1]} was already created!"); }
                else if(isCreator) { Console.WriteLine($"{input[0]} cannot create another team!"); }
                else
                {
                    Console.WriteLine($"Team {input[1]} has been created by {input[0]}!");
                    Team t = new Team(input);
                    existing.Add(t);
                }
                line = Console.ReadLine();
            }
            while (line != "end of assignment")
            {
                string[] input = line.Split("->");
                bool isTeam = existing.Select(x => x.Name).Contains(input[1]);
                bool isMember = existing.Select(x => x.Members).Any(x => x.Contains(input[0]));
                bool isCreator = existing.Select(x => x.Creator).Contains(input[0]);
                if (!isTeam) { Console.WriteLine($"Team {input[1]} does not exist!"); }
                else if (isMember || isCreator) { Console.WriteLine($"Member {input[0]} cannot join team {input[1]}!"); }
                else
                {
                    int index = existing.FindIndex(x => x.Name == input[1]);
                    existing[index].Members.Add(input[0]);
                }
                line = Console.ReadLine();
            }
            for (int i = 0; i < existing.Count; i++)
            {
                if(existing[i].Members.Count == 0)
                {
                    disbanded.Add(existing[i]);
                    existing.RemoveAt(i);
                    i--;
                }
            }
            existing = existing.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name).ToList();
            foreach (var item in existing)
            {
                item.Members.Sort();
            }
            Console.Write(String.Join("", existing));
            disbanded = disbanded.OrderBy(x => x.Name).ToList();
            Console.WriteLine("Teams to disband:");
            foreach (var item in disbanded)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string[] input)
        {
            this.Creator = input[0];
            this.Name = input[1];
            Members = new List<string>();
        }

        public override string ToString()
        {
            string result = this.Name + "\n- " + this.Creator + "\n";
            foreach (var item in this.Members)
            {
                result += "-- " + item + "\n";
            }
            return result;
        }

    }

}
