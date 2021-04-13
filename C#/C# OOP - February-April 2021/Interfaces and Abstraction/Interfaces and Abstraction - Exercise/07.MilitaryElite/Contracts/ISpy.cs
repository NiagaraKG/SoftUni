using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
