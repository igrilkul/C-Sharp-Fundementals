using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle:IVehicle
    {
        private double fuel;
        private double fuelPerKm;
        private double tank;

        public Vehicle(double fuel,double fuelPerKm,double tank)
        {
            this.Tank = tank;
            this.Fuel = fuel;
            this.fuelPerKm = fuelPerKm;
        }

        public double Fuel
        {
            get { return this.fuel; }
            protected set
            {
                if (value <= this.Tank)
                    this.fuel = value;
                else this.fuel = 0;
            }
        }

        public double FuelPerKm
        {
            get { return this.fuelPerKm; }
           protected set { this.fuelPerKm = value; }
        }

        public double Tank
        {
            get { return this.tank; }
            set { this.tank = value; }
            
        }

        public abstract void Drive(double distance);
        public void Refuel(double fuel)
        {
            if(this.Fuel+fuel>this.Tank)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else if(fuel<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (this is Truck)
                {
                    fuel *= 0.95;
                }

                this.Fuel += fuel;
            }
            
        }

        public virtual void DrivingWithoutPeople(double distance)
        { }

        public virtual void DrivingWithPeople(double distance)
        { }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:F2}";
        }
    }
}
