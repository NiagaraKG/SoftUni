using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;
        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps) { this.repairs = new List<IRepair>(); }
        public void AddRepair(IRepair repair) { this.repairs.Add(repair); }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine($"Repairs:");
            foreach (var r in this.Repairs) { result.AppendLine("  " + r.ToString()); }
            return result.ToString().TrimEnd();
        }
    }
}
