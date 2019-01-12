using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<IRepair> Repairs { get; }

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            :base(id,firstName,lastName,salary,corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var repair in Repairs)
            {
                sb.Append("\n  "+repair.ToString());
            }

            return base.ToString() + $"\nRepairs:" + sb.ToString();
        }
    }
}
