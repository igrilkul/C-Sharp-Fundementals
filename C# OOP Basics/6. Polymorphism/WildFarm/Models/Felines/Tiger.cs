using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.weightMultiplier = 1;
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                base.Eat(food);
            }
            else base.WrongFood(food);
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
