

namespace Logger.Appenders
{
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Enums;
    using System;
    using System.Text;

    class ConsoleAppender : Appender
    {
        

        public ConsoleAppender(ILayout layout):base(layout)
        {
        }


        

        public override void AppendMessage(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel >= this.ReportLevel)
            {
        Console.WriteLine(string.Format(this.Layout.Format, dateTime, errorLevel, message));
                this.MessageCount++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine
($"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessageCount}");
            return sb.ToString();
        }

    }
}
