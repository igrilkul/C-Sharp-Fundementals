namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters.RemoveAt(0);
            Object[] args = inputParameters.ToArray();
            string result = string.Empty;

            //Type type= this.GetType().GetField("tankManager").GetType();

            //var festivalcontrolfunction = this.festivalCоntroller.GetType()
            //    .GetMethods()
            //    .FirstOrDefault(x => x.Name == command);

            //result = (string)festivalcontrolfunction
            //        .Invoke(this.festivalCоntroller, new object[] { parameters });

            //var tankManagerInterpreter = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name == command);

           // result = (string)tankManagerInterpreter.Invoke(this.tankManager, args);
            switch (command)
            {
                case "Vehicle":
                    result = this.tankManager.AddVehicle(inputParameters);
                    break;
                case "Part":
                    result = this.tankManager.AddPart(inputParameters);
                    break;
                case "Inspect":
                    result = this.tankManager.Inspect(inputParameters);
                    break;
                case "Battle":
                    result = this.tankManager.Battle(inputParameters);
                    break;
                case "Terminate":
                    result = this.tankManager.Terminate(inputParameters);
                    break;
            }

            return result;
        }
    }
}