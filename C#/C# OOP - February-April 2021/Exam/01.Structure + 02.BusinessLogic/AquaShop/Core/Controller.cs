using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
                return "Successfully added FreshwaterAquarium.";
            }
            if (aquariumType == "SaltwaterAquarium")
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
                return "Successfully added SaltwaterAquarium.";

            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                this.decorations.Add(new Ornament());
                return "Successfully added Ornament.";
            }
            if (decorationType == "Plant")
            {
                this.decorations.Add(new Plant());
                return "Successfully added Plant.";

            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType == "FreshwaterFish")
            {
                var f = new FreshwaterFish(fishName, fishSpecies, price);
                var aquar = aquariums.FirstOrDefault(aq => aq.Name == aquariumName);
                if (aquar.GetType().Name != "FreshwaterAquarium") { return "Water not suitable."; }
                else
                {
                    aquar.AddFish(f);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
            }
            if (fishType == "SaltwaterFish")
            {
                var f = new SaltwaterFish(fishName, fishSpecies, price);
                var aquar = aquariums.FirstOrDefault(aq => aq.Name == aquariumName);
                if (aquar.GetType().Name != "SaltwaterAquarium") { return "Water not suitable."; }
                else
                {
                    aquar.AddFish(f);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }

            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquar = aquariums.FirstOrDefault(aq => aq.Name == aquariumName);
            decimal sum = 0;
            foreach (var f in aquar.Fish) { sum += f.Price; }
            foreach (var d in aquar.Decorations) { sum += d.Price; }
            return $"The value of Aquarium {aquariumName} is {sum:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquar = aquariums.FirstOrDefault(aq => aq.Name == aquariumName);
            aquar.Feed();
            return $"Fish fed: {aquar.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decor = decorations.Models.FirstOrDefault(d => d.GetType().Name == decorationType);
            if (decor == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            else
            {
                aquariums.FirstOrDefault(aq => aq.Name == aquariumName).AddDecoration(decor);
                decorations.Remove(decor);
                return $"Successfully added {decorationType} to {aquariumName}.";
            }
        }

        public string Report()
        {
            StringBuilder s = new StringBuilder();
            foreach (var aq in aquariums)
            {
                s.AppendLine(aq.GetInfo());
            }
            return s.ToString().TrimEnd();
        }
    }
}
