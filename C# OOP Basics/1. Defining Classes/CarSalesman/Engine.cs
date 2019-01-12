using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
   public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
            this.displacement = -1;
            this.efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.efficiency = efficiency;
            this.displacement = -1;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power, displacement)
        {
            this.efficiency = efficiency;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public int Displacement { get => this.displacement; set => this.displacement = value; }
        public string Efficiency { get => this.efficiency; set => this.efficiency = value; }
    }
}
