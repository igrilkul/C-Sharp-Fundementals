using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, 
            decimal price, int additionalParameter)
        {
            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name.Contains(partType));

            Object[] args = { model,weight,price,additionalParameter};

           IPart part = (IPart)Activator.CreateInstance(type,args);

            return part;
        }
    }
}
