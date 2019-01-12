using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, string flourType, string bakingTechnique, double weight)
        {
            this.Name = name;
            this.dough = new Dough(flourType, bakingTechnique, weight);
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else
                    this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else this.toppings.Add(topping);
        }

        private double Calories()
        {
            double toppingsCalories= this.toppings.Sum(x => x.GetCalories());

            return this.dough.GetCalories() + toppingsCalories;
        }

        public string ToString()
        {
            return $"{this.name} - {Calories():F2} Calories.";
        }
    }
}
