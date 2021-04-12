using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
