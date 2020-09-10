using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Appenders;
using Solid_Exercise.Enums;

namespace Solid_Exercise.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Error(string dateTime, string error);

        void Info(string dateTime, string message);

        void Fatal(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Warning(string dateTime, string message);
    }
}
