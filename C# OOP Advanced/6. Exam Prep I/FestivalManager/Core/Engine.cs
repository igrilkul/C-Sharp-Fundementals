
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;

	
	class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

		private IFestivalController festivalCоntroller;
		private ISetController setCоntroller;


        public Engine(IFestivalController festivalController,ISetController setController,
            IReader reader,IWriter writer)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.reader = reader;
            this.writer = writer;
        }

		public void Run()
		{
            string input;

            while ((input=reader.ReadLine())!="END")
			{
				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (TargetInvocationException ex)
				{
					this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
				}
			}

			string report = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(report);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(" ");

			var command = tokens[0];
			var parameters = tokens.Skip(1).ToArray();


            string result;
			if (command == "LetsRock")
			{
				result = this.setCоntroller.PerformSets();
			}
            else
            {
                var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

                result = (string)festivalcontrolfunction
                        .Invoke(this.festivalCоntroller, new object[] { parameters });
            }

            return result;
		}

       
    }
}