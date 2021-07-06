using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }
        private readonly List<IDecoration> decorations;
        public IReadOnlyCollection<IDecoration> Models => this.decorations;

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(d => d.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model);
        }
    }
}
