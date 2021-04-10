using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Mission : IMission
    {
        public string CodeName { get; private set; }
        public State State { get; private set; }
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public void CompleteMission() { this.State = State.Finished; }
        public override string ToString() { return $"Code Name: {this.CodeName} State: {this.State}"; }
    }
}
