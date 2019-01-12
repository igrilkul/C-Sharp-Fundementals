using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<IPrivate> Privates { get; }

        public LieutenantGeneral(int id,string firstName,string lastName,decimal salary)
            :base(id,firstName,lastName,salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var privatex in this.Privates)
            {
                sb.Append("\n  "+privatex.ToString());
            }
            return base.ToString()+$"\nPrivates:"+sb.ToString();
        }
    }
}
