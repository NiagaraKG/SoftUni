using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
    }
}
