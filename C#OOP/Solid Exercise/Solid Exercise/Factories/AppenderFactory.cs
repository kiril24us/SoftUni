using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Appenders;
using Solid_Exercise.Enums;
using Solid_Exercise.Layouts;
using Solid_Exercise.Loggers;

namespace Solid_Exercise.Factories
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            type = type.ToLower();

            switch (type)
            {
                case"consoleappender":
                        return new ConsoleAppender(layout) { ReportLevel = reportLevel};
                case "fileappender":
                    return new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };
                default:
                    throw new ArgumentException("Invalid Appender type!");
            }
        }
    }
}
