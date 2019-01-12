using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;

namespace Logger.Appenders.Factories
{
    interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
