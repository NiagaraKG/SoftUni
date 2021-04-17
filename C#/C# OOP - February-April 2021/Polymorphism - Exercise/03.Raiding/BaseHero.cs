using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public virtual string CastAbility() { return ""; }
    }
}
