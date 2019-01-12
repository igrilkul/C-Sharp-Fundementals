using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Cat:Animal
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {

        }

        public override string ProduceSound(string msg)
        {
            msg = "Meow meow";
            return msg;
        }
    }
}
