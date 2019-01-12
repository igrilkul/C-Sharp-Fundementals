using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        protected double weightMultiplier;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public int FoodEaten { get => foodEaten; set => foodEaten = value; }
        public double Weight { get => weight; set => weight = value; }
        public string Name { get => name; set => name = value; }

        public abstract string ProduceSound();

        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += this.weightMultiplier * food.Quantity;
        }

        protected void WrongFood(Food food)
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
