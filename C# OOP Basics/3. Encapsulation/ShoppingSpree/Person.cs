using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else this.money = value;
            }
        }

        public void Purchase(Product product)
        {
            if(this.Money>=product.Cost)
            {
                this.bag.Add(product);
                this.Money = this.money - product.Cost;
                Console.WriteLine($"{this.name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
        }

        public string ToString()
        {
            if (this.bag.Count > 0)
                return $"{this.name} - {string.Join(", ", this.bag.Select(x => x.Name))}";
            else return $"{this.name} - Nothing bought";
        }
    }
}
