using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary) { this.privates = new List<IPrivate>(); }
        public void AddPrivate(IPrivate @private) { this.privates.Add(@private); }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            result.AppendLine($"Privates:");
            foreach (var p in this.Privates) { result.AppendLine("  " + p.ToString()); }
            return result.ToString().TrimEnd();
        }
    }
}
