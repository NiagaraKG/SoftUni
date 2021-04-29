using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height, width;
        public Rectangle(double h, double w) { this.height = h; this.width = w; }
        public override double CalculateArea() { return this.height * this.width; }
        public override double CalculatePerimeter() { return 2 * (this.height + this.width); }
        public override string Draw() { return base.Draw() + this.GetType().Name; }

    }
}
