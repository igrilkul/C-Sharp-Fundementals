using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid flour type");
                }
                else this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid baking technique");
                }
                else this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                else this.weight = value;
            }
        }

        public double GetCalories()
        {
            double flourModifier=-1;
            double bakingModifier=-1;

            switch(this.flourType.ToLower())
            {
                case "white": flourModifier = 1.5; break;
                case "wholegrain": flourModifier = 1.0; break;
            }

            switch(this.bakingTechnique.ToLower())
            {
                case "crispy":bakingModifier = 0.9; break;
                case "chewy":bakingModifier = 1.1; break;
                case "homemade":bakingModifier = 1.0; break;
            }

            return (2 * this.weight) * flourModifier * bakingModifier;
        }
    }
}
