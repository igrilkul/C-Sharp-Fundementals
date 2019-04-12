﻿namespace TheTankGame.Core
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


            var tankManagerFunction = this.tankManager.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name.Contains(command));

            result = (string)tankManagerFunction
                    .Invoke(this.tankManager, new object[] { inputParameters });

            return result;
        }
    }
}