﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
   public class Truck : Vehicle
    {
        private const int TruckCapacity = 5;
        public Truck() : base(TruckCapacity)
        {
        }
    }
}
