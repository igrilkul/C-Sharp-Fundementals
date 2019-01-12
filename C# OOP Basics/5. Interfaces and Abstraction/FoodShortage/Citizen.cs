using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : Person,IIdentifiable
    {
        public string Id { get; }
        public string Birthdate { get; }
        private int foodAmount=10;

        public override void BuyFood()
        {
            this.Food += foodAmount;
        }

        public Citizen(string name,int age, string id,string birthdate):base(name,age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
