using Logger.Appenders.Contracts;
using Logger.Appenders.Factories;
using Logger.Core.Contracts;
using Logger.Layouts.Contracts;
using Logger.Layouts.Factories;
using Logger.Layouts.Factories.Contracts;
using Logger.Loggers.Enums;
using System;
using System.Collections.Generic;

namespace Logger.Core
{
    class CommandInterpreter : ICommandInterpreter
    {

        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.layoutFactory = new LayoutFactory();
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
        }
        
        public void AddAppender(string[] tokens)
        {
            ILayout layout = layoutFactory.CreateLayout(tokens[1]);
            IAppender appender = appenderFactory.CreateAppender(tokens[0], layout);
            appender.ReportLevel = ReportLevel.INFO;

            if (tokens.Length == 3)
            {
                appender.ReportLevel = Enum.Parse<ReportLevel>(tokens[2],true);
            }

            this.appenders.Add(appender);
        }

        public void AddMessage(string[] tokens)
        {
            //INFO|3/26/2015 2:08:11 PM|Everything seems fine
            //WARNING | 3 / 26 / 2015 2:22:13 PM | Warning: ping is too high - disconnect imminent
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(tokens[0],true);
            string dateTime = tokens[1];
            string message = tokens[2];

            foreach(var appender in appenders)
            {
                appender.AppendMessage(dateTime, reportLevel, message);
            }
        }

        public void LoggerInfo()
        {
            Console.WriteLine("Logger info");
            foreach(var appender in this.appenders)
            {
                Console.Write(appender);
            }
        }
    }
}
