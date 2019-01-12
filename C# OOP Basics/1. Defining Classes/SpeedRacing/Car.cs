using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
   public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionFor1km;
        private double kmsTravelled=0;

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionFor1km = fuelConsumptionFor1km;
        }
       

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionFor1km
        {
            get { return this.fuelConsumptionFor1km; }
            set { this.fuelConsumptionFor1km = value; }
        }

        public double KmsTravelled
        {
            get { return this.kmsTravelled; }
            set { this.kmsTravelled = value; }
        }

        public void CanTravel(int distance)
        {
            if(this.fuelConsumptionFor1km*distance<=this.fuelAmount)
            {
                this.fuelAmount -= this.fuelConsumptionFor1km * distance;
                this.kmsTravelled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
