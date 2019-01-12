using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Tomcat:Cat
    {
        public Tomcat(string name, int age, string gender="Male") : base(name, age, gender)
        {

        }

        public override string ProduceSound(string msg)
        {
            msg = "MEOW";
            return msg;
        }
    }
}
