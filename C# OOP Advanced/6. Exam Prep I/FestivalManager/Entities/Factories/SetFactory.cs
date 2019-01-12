
namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type assemblyType = Assembly.GetCallingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name == type);

            ISet set = (ISet)Activator.CreateInstance(assemblyType, name);

            return set;
		}
	}




}
