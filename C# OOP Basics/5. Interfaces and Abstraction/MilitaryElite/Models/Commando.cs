using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<IMission> Missions { get; }

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var mission in this.Missions)
            {
                sb.Append("\n  " + mission.ToString());
            }
            return base.ToString() + $"\nMissions:" + sb.ToString();
        }
    }
}
