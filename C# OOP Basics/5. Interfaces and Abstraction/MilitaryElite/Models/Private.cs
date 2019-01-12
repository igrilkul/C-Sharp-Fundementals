using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; }

        public Private(int id,string firstName,string lastName, decimal Salary):base(id,firstName,lastName)
        {
            this.Salary = Salary;
        }

        public override string ToString()
        {
            return base.ToString()+$" Salary: {this.Salary:F2}";
        }
    }
}
