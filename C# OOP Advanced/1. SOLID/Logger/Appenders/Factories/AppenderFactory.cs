using System;
using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Logger.Loggers;

namespace Logger.Appenders.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            switch(type)
            {
                case "ConsoleAppender":
                    {
                        IAppender consoleAppender = new ConsoleAppender(layout);
                        return consoleAppender;
                    }
                case "FileAppender":
                    {
                        IAppender fileAppender = new FileAppender(layout, new LogFile());
                        return fileAppender;
                    }
                default:
                    throw new ArgumentException("Invalid appender type");
            }
        }
    }
}
