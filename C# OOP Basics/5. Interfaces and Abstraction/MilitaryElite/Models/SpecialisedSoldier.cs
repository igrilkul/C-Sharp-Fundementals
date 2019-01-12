using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public string Corps
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException();
                }
                this.corps = value;
            }
        }


        public SpecialisedSoldier(int id,string firstName,string lastName,decimal salary,string corps)
            :base(id,firstName,lastName,salary)
        {
            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString()+$"\nCorps: {this.Corps}";
        }
    }
}
