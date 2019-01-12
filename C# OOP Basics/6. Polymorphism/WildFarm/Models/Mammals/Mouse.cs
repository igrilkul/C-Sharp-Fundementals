using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.weightMultiplier = 0.10;
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                base.Eat(food);
            }
            else base.WrongFood(food);
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
