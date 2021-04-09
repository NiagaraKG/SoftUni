using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<string, ISoldier> soliders = new Dictionary<string, ISoldier>();
            while (input[0] != "End")
            {
                string id = input[1]; string firstName = input[2], lastName = input[3];
                if (input[0] == "Private") { soliders[id] = new Private(id, firstName, lastName, decimal.Parse(input[4])); }
                else if (input[0] == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(input[4]);
                    LieutenantGeneral curr = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < input.Length; i++) { curr.AddPrivate((IPrivate)soliders[input[i]]); }
                    soliders[id] = curr;
                }
                else if (input[0] == "Spy") { soliders[id] = new Spy(id, firstName, lastName, int.Parse(input[4])); }
                else if (input[0] == "Engineer")
                {
                    decimal salary = decimal.Parse(input[4]);
                    if (Enum.TryParse(input[5], out Corps corps))
                    {
                        IEngineer curr = new Engineer(id, firstName, lastName, salary, corps);
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            IRepair r = new Repair(input[i], int.Parse(input[i + 1]));
                            curr.AddRepair(r);
                        }
                        soliders[id] = curr;
                    }
                }
                else if (input[0] == "Commando")
                {
                    decimal salary = decimal.Parse(input[4]);
                    if (Enum.TryParse(input[5], out Corps corps))
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string codeName = input[i];
                            bool isValidState = Enum.TryParse(input[i + 1], out State state);
                            if (!isValidState) { continue; }
                            commando.AddMission(new Mission(codeName, state));
                        }
                        soliders[id] = commando;
                    }
                }
                input = Console.ReadLine().Split();
            }
            foreach (var s in soliders.Values) { Console.WriteLine(s.ToString()); }
        }
    }
}
