

namespace Logger.Appenders.Contracts
{
    using Logger.Loggers.Enums;
    using System;

    public interface IAppender
    {
        void AppendMessage(string dateTime, ReportLevel errorLevel, string message);
        ReportLevel ReportLevel { get; set; }
        String ToString();
        int MessageCount {get; }
    }
}
