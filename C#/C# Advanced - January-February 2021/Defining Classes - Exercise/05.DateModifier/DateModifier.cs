using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
       public static int Calculate(string first, string second)
        {
            int[] date = first.Split().Select(int.Parse).ToArray();
            DateTime date1 = new DateTime(date[0], date[1], date[2]);
            date = second.Split().Select(int.Parse).ToArray();
            DateTime date2 = new DateTime(date[0], date[1], date[2]);
            return Math.Abs((date1-date2).Days);
        }
    }
}
