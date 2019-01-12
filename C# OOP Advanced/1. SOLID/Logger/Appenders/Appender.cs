using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Logger.Loggers.Enums;

namespace Logger.Appenders
{
   public abstract class Appender : IAppender
    {
        private ILayout layout;
        private ReportLevel reportLevel;
        private int messageCount;


        public Appender(ILayout layout)
        {
            this.Layout = layout;
            this.MessageCount = 0;
        }

        public ReportLevel ReportLevel { get => reportLevel; set => reportLevel = value; }
        public int MessageCount { get => messageCount; set => messageCount = value; }
        public ILayout Layout { get => layout; set => layout = value; }

        public abstract void AppendMessage(string dateTime, ReportLevel errorLevel, string message);

        //public abstract String ToString();
        
    }
}
