using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Appenders;
using Solid_Exercise.Enums;

namespace Solid_Exercise.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }
        public IAppender[] Appenders { 
            get
            {
                return this.appenders;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Appenders), "Value cannot be null");
                }
                this.appenders = value;
            }
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string error)
        {
            Append(dateTime, ReportLevel.Error, error);
        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Fatal, message);
        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Warning, message);
        }

        public void Info(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Info, message);
        }

        private void Append(string dateTime, ReportLevel logLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, logLevel, message);
            }
        }
    }
}
