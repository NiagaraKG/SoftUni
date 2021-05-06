using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int min, int max)
        {
            this.ValidateRange(min, max);
            this.minValue = min;
            this.maxValue = max;
        }
        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                int value = (int)obj;
                if (value < this.minValue || value > this.maxValue) { return false; }
                return true;
            }
            else { throw new InvalidOperationException("Cannot validate given data type!"); }
        }
        private void ValidateRange(int min, int max)
        {
            if (min > max) { throw new ArgumentException("Ïnvalid range!"); }
        }
    }
}
