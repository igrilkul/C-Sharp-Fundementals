

namespace Logger.Appenders
{
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Contracts;
    using Logger.Loggers.Enums;
    
    using System.IO;
    using System.Text;

    public class FileAppender : Appender
    {
        private string path = "log.txt";
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout,ILogFile logFile):base(layout)
        {
            this.logFile = logFile;
        }

        //public void AppendMessage(string dateTime,ReportLevel errorLevel,string message)
        //{
        //    if (errorLevel >= this.ReportLevel)
        //    {
        //        string contents = string.Format(layout.Format, dateTime, errorLevel, message) + "\n";
        //        File.AppendAllText(path, contents);
        //        this.logFile.Write(contents);
        //        MessageCount++;
        //    }
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine
($"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessageCount}, File size {this.logFile.Size}");
            return sb.ToString();
        }

        public override void AppendMessage(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel >= this.ReportLevel)
            {
                string contents = string.Format(Layout.Format, dateTime, errorLevel, message) + "\n";
                File.AppendAllText(path, contents);
                this.logFile.Write(contents);
                MessageCount++;
            }
        }
    }
}
