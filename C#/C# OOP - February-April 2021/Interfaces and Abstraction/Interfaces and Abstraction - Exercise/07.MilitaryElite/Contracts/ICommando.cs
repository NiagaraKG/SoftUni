using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
        void AddMission(IMission mission);
    }
}
