using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : Person
    {
        private int foodAmount= 5;
        
        public override void BuyFood()
        {
            this.Food += foodAmount;
        }

       
        public string Group { get; }

        public Rebel(string name,int age,string group):base(name,age)
        {
            this.Group = group;
        }
    }
}
