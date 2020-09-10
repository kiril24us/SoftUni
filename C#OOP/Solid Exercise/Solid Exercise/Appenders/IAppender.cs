 using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Enums;
using Solid_Exercise.Layouts;

namespace Solid_Exercise.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel logLevel, string message);
    }
}
