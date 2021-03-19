using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const double CoffeeMilliliters = 50;
        public const decimal CoffeePrice = (decimal)3.50;
        public double Caffeine { get; set; }       
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters) { this.Caffeine = caffeine; }

    }
}
