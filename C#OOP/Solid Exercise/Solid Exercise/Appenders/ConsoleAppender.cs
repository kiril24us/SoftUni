using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Enums;
using Solid_Exercise.Layouts;

namespace Solid_Exercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
            
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            this.Counter++;
            if (reportLevel > this.ReportLevel)
            {
                Console.WriteLine(this.Layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}
