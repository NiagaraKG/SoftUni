using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        public string ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private  set; }
        public Soldier(string id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
