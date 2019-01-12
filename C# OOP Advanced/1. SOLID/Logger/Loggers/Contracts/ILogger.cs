

namespace Logger.Loggers.Contracts
{

    public interface ILogger
    {
        void Error(string dateTime, string error);
        void Info(string dateTime, string message);
        void Fatal(string dateTime, string message);
        void Critical(string dateTime, string message);

    }
}
