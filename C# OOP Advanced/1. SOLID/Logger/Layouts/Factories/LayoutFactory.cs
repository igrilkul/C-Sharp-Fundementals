using Logger.Layouts.Contracts;
using Logger.Layouts.Factories.Contracts;
using System;

namespace Logger.Layouts.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeToLower = type.ToLower();
            switch(typeToLower)
            {
                case "simplelayout":
                    {
                        ILayout simpleLayout = new SimpleLayout();
                        return simpleLayout;
                    }
                case "xmllayout":
                    {
                        ILayout xmlLayout = new XmlLayout();
                        return xmlLayout;
                    }
                default: throw new ArgumentException("Invalid layout type");
            }
        }
    }
}
