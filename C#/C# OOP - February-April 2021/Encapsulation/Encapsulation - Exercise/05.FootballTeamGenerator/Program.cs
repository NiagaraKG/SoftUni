using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string[] input = Console.ReadLine().Split(";");
            while (input[0] != "END")
            {
                try
                {
                    if (input[0] == "Team") { teams.Add(new Team(input[1])); }
                    else if (input[0] == "Add")
                    {
                        if (teams.Any(t => t.Name == input[1]))
                        {
                            teams.FirstOrDefault(t => t.Name == input[1]).Add(new Player
                            (input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7])));
                        }
                        else { Console.WriteLine($"Team {input[1]} does not exist."); }
                    }
                    else if (input[0] == "Remove")
                    {
                        if (teams.Any(t => t.Name == input[1])) { teams.FirstOrDefault(t => t.Name == input[1]).Remove(input[2]); }
                        else { Console.WriteLine($"Team {input[1]} does not exist."); }
                    }
                    else if(input[0] == "Rating")
                    {
                        if (teams.Any(t => t.Name == input[1])) { teams.FirstOrDefault(t => t.Name == input[1]).Rating(); }
                        else { Console.WriteLine($"Team {input[1]} does not exist."); }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                input = Console.ReadLine().Split(";");
            }
        }
    }
}
