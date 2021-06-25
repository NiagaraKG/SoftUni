using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> carsByModel;
        public CarRepository() { this.carsByModel = new Dictionary<string, ICar>(); }
        public void Add(ICar model)
        {
            if(this.carsByModel.ContainsKey(model.Model))
            { throw new ArgumentException($"Car {model.Model} is already create."); }
            this.carsByModel.Add(model.Model, model);
        }
        public ICar GetByName(string name)
        {
            return carsByModel.FirstOrDefault(c => c.Key == name).Value;
            /*ICar c = null;
            if (this.carsByModel.ContainsKey(name)) { c = this.carsByModel[name]; }
            return c;*/
        }
        public IReadOnlyCollection<ICar> GetAll() { return this.carsByModel.Values.ToList(); }
        public bool Remove(ICar model) { return this.carsByModel.Remove(model.Model); }
    }
}
