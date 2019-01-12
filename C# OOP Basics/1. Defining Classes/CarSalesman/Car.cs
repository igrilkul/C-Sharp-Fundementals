using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = -1;
            this.color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.color = color;
        }

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public int Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }

        
        public void ToString()
        {
            Console.WriteLine($"{this.model}:");
            Console.WriteLine($"  {this.Engine.Model}:");
            Console.WriteLine($"    Power: {this.Engine.Power}");

            if (this.Engine.Displacement==-1)
            {
                Console.WriteLine($"    Displacement: n/a");
            }
            else
            {
                Console.WriteLine($"    Displacement: {this.Engine.Displacement}");
            }

            
                Console.WriteLine($"    Efficiency: {this.Engine.Efficiency}");
            

            if (this.Weight==-1)
            {
                Console.WriteLine($"  Weight: n/a");
            }
            else
            {
                Console.WriteLine($"  Weight: {this.Weight}");
            }

           
                Console.WriteLine($"  Color: {this.Color}");
            
        }
    }
}
