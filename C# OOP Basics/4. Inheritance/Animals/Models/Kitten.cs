using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Kitten:Cat
    {
        public Kitten(string name, int age, string gender="Female") : base(name, age, gender)
        {

        }

        public override string ProduceSound(string msg)
        {
            msg = "Meow";
            return msg;
        }
    }
}
