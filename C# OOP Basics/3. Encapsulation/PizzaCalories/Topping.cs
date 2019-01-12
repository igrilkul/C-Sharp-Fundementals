using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                else
                    this.type = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                else this.weight = value;
            }
        }

        public double GetCalories()
        {
            double typeModifier = -1;
            switch(this.type.ToLower())
            {
                case "meat":typeModifier = 1.2; break;
                case "veggies":typeModifier = 0.8;break;
                case "cheese": typeModifier = 1.1; break;
                case "sauce": typeModifier = 0.9; break;
            }

            return (2 * this.weight) * typeModifier;
        }
    }
}
