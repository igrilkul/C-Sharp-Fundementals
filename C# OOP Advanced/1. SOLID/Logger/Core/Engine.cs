using Logger.Core.Contracts;
using System;

namespace Logger.Core
{
    class Engine : IEngine
    {

        private CommandInterpreter commandInterpreter;

        public Engine (CommandInterpreter commandInterpreter)
        {
            this.CommandInterpreter = commandInterpreter;
        }

        internal CommandInterpreter CommandInterpreter { get => commandInterpreter; set => commandInterpreter = value; }

        public void Run()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());
           

            //Add appenders
            for(int i=0;i<numberOfAppenders;i++)
            {
                string[] tokens = Console.ReadLine().Split();
                CommandInterpreter.AddAppender(tokens);
            }

            //Add messages
            string input;
            while((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split('|');
                CommandInterpreter.AddMessage(tokens);
            }

            //Print logger info
            commandInterpreter.LoggerInfo();

        }
    }
}
