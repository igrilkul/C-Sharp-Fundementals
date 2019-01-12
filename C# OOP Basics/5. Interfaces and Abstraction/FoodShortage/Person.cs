using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public abstract class Person : ICreatureInfo, IBuyer
    
    {

        public string Name { get; }

        public int Age { get; }

        public int Food { get; protected set; }

        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public abstract void BuyFood();
        
    }
}
