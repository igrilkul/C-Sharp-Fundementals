using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private bool isFull;
        private Vehicle[] garage;
        private readonly List<Product> products;

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int GarageSlots { get => garageSlots; set => garageSlots = value; }

        public bool IsFull
        { get { return this.Products.Sum(p => p.Weight) >= this.Capacity; } }

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        protected Storage(string name, int capacity, int garageSlots,IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[this.garageSlots];
            this.products = new List<Product>();

            this.FillGarageWithInitialVehicles(vehicles);
        }

        private void FillGarageWithInitialVehicles(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;
            foreach(var vehicle in vehicles)
            {
                garage[index++] = vehicle;
            }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if(garageSlot>=this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if(garage[garageSlot]==null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot,Storage deliveryLocation)
        {
            Vehicle vehicleToMove = this.GetVehicle(garageSlot);

            for(int i=0;i<deliveryLocation.garage.Length;i++)
            {
                if(deliveryLocation.garage[i]==null)
                {
                    deliveryLocation.garage[i] = vehicleToMove;
                    this.garage[garageSlot] = null;
                    return i;
                }
            }

            throw new InvalidOperationException("No room in garage!");
        }

        public int UnloadVehicle(int garageSlot)
        {
            if(IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            int productsCount=0;
            var vehicleToUnload=GetVehicle(garageSlot);

            while(vehicleToUnload.Trunk.Count>0 && !IsFull)
            {
                Product productToLoad = vehicleToUnload.Unload();
                products.Add(productToLoad);
                productsCount++;
            }
            return productsCount;
        }
    }
}
