using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null) { return false; }
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (var p in properties)
            {
                MyValidationAttribute[] attributes = p.GetCustomAttributes().Where(x => x is MyValidationAttribute)
                                                                            .Cast<MyValidationAttribute>().ToArray();
                foreach (var att in attributes)
                {
                    if (!att.IsValid(p.GetValue(obj))) { return false; }
                }
            }
            return true;
        }
    }
}
