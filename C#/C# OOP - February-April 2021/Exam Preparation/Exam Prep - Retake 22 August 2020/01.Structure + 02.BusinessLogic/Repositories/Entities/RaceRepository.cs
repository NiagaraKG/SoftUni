using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IDictionary<string, IRace> racesByName;
        public RaceRepository() { this.racesByName = new Dictionary<string, IRace>(); }

        public void Add(IRace model)
        {
            if (this.racesByName.ContainsKey(model.Name))
            { throw new ArgumentException($"Race {model.Name} is already created."); }
            this.racesByName.Add(model.Name, model);
        }
        public IRace GetByName(string name)
        {
            return racesByName.FirstOrDefault(r => r.Key == name).Value;
            /*IRace r = null;
            if (this.racesByName.ContainsKey(name)) { r = this.racesByName[name]; }
            return r;*/
        }
        public IReadOnlyCollection<IRace> GetAll() { return this.racesByName.Values.ToList(); }
        public bool Remove(IRace model) { return this.racesByName.Remove(model.Name); }
    }
}
