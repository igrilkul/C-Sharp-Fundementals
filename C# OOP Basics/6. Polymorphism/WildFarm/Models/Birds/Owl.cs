using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name,double weight,double wingSize)
            :base(name,weight,wingSize)
        {
            this.weightMultiplier = 0.25;
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                base.Eat(food);
            }
            else
                base.WrongFood(food);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
