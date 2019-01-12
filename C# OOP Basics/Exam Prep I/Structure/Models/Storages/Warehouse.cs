﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
    public class Warehouse : Storage
    {
        private const int WarehouseCapacity = 10;
        private const int WarehouseGarageSlots= 10;
        private static Vehicle[] DefaultVehicles =
            {
                new Semi(),
                new Semi(),
                new Semi()
            };

        public Warehouse(string name) 
            : base(name, WarehouseCapacity, WarehouseGarageSlots, DefaultVehicles)
        {
        }
    }
}
