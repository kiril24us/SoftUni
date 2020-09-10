using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Enums;
using Solid_Exercise.Layouts;
using Solid_Exercise.Loggers;

namespace Solid_Exercise.Appenders
{
    public class FileAppender :  Appender
    {
        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            this.Counter++;
            if (reportLevel >= this.ReportLevel)
            {
                this.LogFile.Write(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.LogFile.Size}";
        }
    }
}
