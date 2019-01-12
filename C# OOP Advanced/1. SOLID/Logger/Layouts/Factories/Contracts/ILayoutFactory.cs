using Logger.Layouts.Contracts;

namespace Logger.Layouts.Factories.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
