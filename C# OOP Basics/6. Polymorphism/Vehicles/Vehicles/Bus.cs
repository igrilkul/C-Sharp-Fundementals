using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle,IBus
    {
        private double ACConsumption=0;

        public Bus(double fuel, double fuelPerKm,double tank) : base(fuel, fuelPerKm,tank)
        {
            
        }

        public override void Drive(double distance)
        {
            this.FuelPerKm += ACConsumption;

            if (this.Fuel >= this.FuelPerKm * distance)
            {
                this.Fuel -= this.FuelPerKm * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

       

        public override void DrivingWithPeople(double distance)
        {
            this.ACConsumption = 1.4;
            this.Drive(distance);
        }

        public override void DrivingWithoutPeople(double distance)
        {
            this.ACConsumption = 0;
            this.Drive(distance);
        }

        

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:F2}";
        }
    }
}
