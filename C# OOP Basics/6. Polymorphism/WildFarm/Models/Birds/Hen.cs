﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen:Bird
    {

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.weightMultiplier = 0.35;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
        }
    }
}
