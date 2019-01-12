using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Car : Vehicle
    {
        private const double ACConsumption = 0.9;


        public Car(double fuel,double fuelPerKm,double tank):base(fuel,fuelPerKm, tank)
        {
            this.FuelPerKm += ACConsumption;
        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * this.FuelPerKm;

            if (this.Fuel >= neededFuel)
            {
                this.Fuel -= neededFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }

        }


       

        
    }
}
