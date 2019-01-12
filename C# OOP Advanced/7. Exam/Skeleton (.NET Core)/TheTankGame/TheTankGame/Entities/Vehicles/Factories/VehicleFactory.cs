using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model,
            double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == vehicleType);

            IAssembler assembler = new VehicleAssembler();

            Object[] args = { model, weight, price, attack, defense, hitPoints,assembler };

            IVehicle vehicle = (IVehicle)Activator.CreateInstance(type,args);

            return vehicle;
        }
    }
}
