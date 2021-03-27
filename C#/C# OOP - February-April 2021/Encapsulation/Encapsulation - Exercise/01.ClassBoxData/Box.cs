using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length, width, height;
        private double Length
        {
            get { return this.length; }
            set
            {
                if (value <= 0) { throw new ArgumentException("Length cannot be zero or negative."); }
                else { this.length = value; }
            }
        }
        private double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0) { throw new ArgumentException("Width cannot be zero or negative."); }
                else { this.width = value; }
            }
        }
        private double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0) { throw new ArgumentException("Height cannot be zero or negative."); }
                else { this.height = value; }
            }
        }
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double SurfaceArea()
        { return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height; }
        public double LateralSurfaceArea()
        { return 2 * this.Length * this.Height + 2 * this.Width * this.Height; }
        public double Volume()
        { return this.Length*this.Width*this.Height; }
    }
}
