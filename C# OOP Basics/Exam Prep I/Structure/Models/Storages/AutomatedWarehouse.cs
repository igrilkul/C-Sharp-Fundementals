using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
    public class AutomatedWarehouse : Storage
    {
        private const int AutomatedWareHouseCapacity = 1;
        private const int AutomatedWareHouseGarageSlots = 2;

        private static Vehicle[] DefaultVehicles =
        {
            new Truck()
        };

        public AutomatedWarehouse(string name) 
            : base(name, AutomatedWareHouseCapacity, AutomatedWareHouseGarageSlots, DefaultVehicles)
        {
        }
    }
}
