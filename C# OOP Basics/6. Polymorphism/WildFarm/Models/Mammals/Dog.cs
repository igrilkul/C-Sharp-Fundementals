using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public class Dog : Mammal
    {
        public Dog(string name, double weight,  string livingRegion) 
            : base(name, weight,  livingRegion)
        {
            this.weightMultiplier = 0.4;
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
            return "Woof!";
        }
    }
}
