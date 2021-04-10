using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps)
    : base(id, firstName, lastName, salary, corps) { this.missions = new List<IMission>(); }
        public void AddMission(IMission mission) { this.missions.Add(mission); }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine($"Missions:");
            foreach (var m in this.Missions) { result.AppendLine("  " + m.ToString()); }
            return result.ToString().TrimEnd();
        }
    }
}
