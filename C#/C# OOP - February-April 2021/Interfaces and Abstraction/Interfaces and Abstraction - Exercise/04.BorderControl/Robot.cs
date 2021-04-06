using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : IID
    {
        public string Model { get; set; }
        public string ID { get; set; }
        public Robot(string model, string id)
        {
            this.Model = model;
            this.ID = id;
        }
    }
}
