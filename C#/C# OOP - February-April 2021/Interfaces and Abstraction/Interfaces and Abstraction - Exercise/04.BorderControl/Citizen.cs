using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    class Citizen : IID
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public Citizen(string name, int age, string ID)
        {
            this.Name = name;
            this.Age = age;
            this.ID = ID;
        }
    }
}
