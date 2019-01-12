

namespace Logger.Layouts
{
    using Logger.Layouts.Contracts;

    class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
