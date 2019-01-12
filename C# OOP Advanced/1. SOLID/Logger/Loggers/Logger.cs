

namespace Logger.Loggers
{
    using Appenders.Contracts;
    using global::Logger.Loggers.Enums;
    using Loggers.Contracts;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender,IAppender fileAppender):this(consoleAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }

        private void CompileMessage(string dateTime,ReportLevel level,string message)
        {
            this.fileAppender?.AppendMessage(dateTime, level, message);
            this.consoleAppender?.AppendMessage(dateTime, level, message);
        }

        public void Critical(string dateTime, string errorMessage)
        {
            CompileMessage(dateTime, ReportLevel.CRITICAL, errorMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            CompileMessage(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Fatal(string dateTime, string errorMessage)
        {
            CompileMessage(dateTime, ReportLevel.FATAL, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            CompileMessage(dateTime, ReportLevel.INFO, infoMessage);
        }
    }
}
