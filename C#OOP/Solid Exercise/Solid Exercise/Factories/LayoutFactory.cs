using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Layouts;

namespace Solid_Exercise.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "jsonlayout":
                    return new JsonLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid Layout");
            }
        }
    }
}
