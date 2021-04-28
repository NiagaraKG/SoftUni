﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double r) { this.radius = r; }
        public override double CalculateArea() { return Math.PI * Math.Pow(this.radius, 2); }
        public override double CalculatePerimeter() { return 2 * Math.PI * this.radius; }
        public override string Draw() { return base.Draw() + this.GetType().Name; }
    }
}
