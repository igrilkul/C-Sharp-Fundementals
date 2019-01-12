
namespace Logger.Core.Contracts
{
    interface ICommandInterpreter
    {
        void AddAppender(string[] args);
        void AddMessage(string[] args);
        void LoggerInfo();
    }
}
