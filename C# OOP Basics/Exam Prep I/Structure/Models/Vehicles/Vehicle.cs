using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public abstract class Vehicle
    {
        private int capacity;
        private readonly List<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        //Encapsulates the list with a read-only wrapper to be immutable, more security
        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public void LoadProduct(Product product)
        {
            if(IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            //check count
            var productToReturn = this.trunk[this.trunk.Count-1];
            this.trunk.Remove(productToReturn);
            return productToReturn;
        }

        public int Capacity { get; }
        public bool IsFull { get { return Trunk.Sum(p => p.Weight) >= Capacity; } }

        public bool IsEmpty { get { return Trunk.Count == 0; } }
    }
}
