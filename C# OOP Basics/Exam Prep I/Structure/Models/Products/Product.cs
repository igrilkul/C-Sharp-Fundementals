﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
   public abstract class Product
    {
        private double price;
        private double weight;

        protected Product(double price,double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price { get => price; set
            {
                if(value<0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }
        public double Weight { get => weight; set => weight = value; }
    }
}
