using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> driversByName;
        public DriverRepository() { this.driversByName = new Dictionary<string, IDriver>(); }

        public void Add(IDriver model)
        {
            if (this.driversByName.ContainsKey(model.Name))
            { throw new ArgumentException($"Driver {model.Name} is already created."); }
            this.driversByName.Add(model.Name, model);
        }
        public IDriver GetByName(string name)
        {
            return driversByName.FirstOrDefault(d => d.Key == name).Value;
            /*IDriver d = null;
            if (this.driversByName.ContainsKey(name)) { d = this.driversByName[name]; }
            return d;*/
        }
        public IReadOnlyCollection<IDriver> GetAll() { return this.driversByName.Values.ToList(); }
        public bool Remove(IDriver model) { return this.driversByName.Remove(model.Name); }
    }
}
