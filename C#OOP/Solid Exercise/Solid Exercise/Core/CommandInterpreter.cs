using Solid_Exercise.Appenders;
using Solid_Exercise.Enums;
using Solid_Exercise.Factories;
using Solid_Exercise.Layouts;
using Solid_Exercise.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_Exercise.Core
{
    public class CommandInterpreter
    {
        private readonly List<IAppender> appenders;
        private ILogger logger;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();            
        }
        public void Read(string[] args)
        {
            string command = args[0];
            if (command.Contains("Create"))
            {
                CreateAppender(args);
            }
            else if(command.Contains("Append"))
            {
                logger = new Logger(appenders.ToArray());
                AppendMessage(args);
            }
            else if (command == "END")
            {
                PrintInfo();
            }
        }

        private void AppendMessage(string[] inputInfo)
        {
            string loggerMethodType = inputInfo[1];
            string date = inputInfo[2];
            string message = inputInfo[3];

            if (loggerMethodType == "INFO")
            {
                logger.Info(date, message);
            }
            else if (loggerMethodType == "WARNING")
            {
                logger.Info(date, message);
            }
            else if (loggerMethodType == "ERROR")
            {
                logger.Info(date, message);
            }
            else if (loggerMethodType == "CRITICAL")
            {
                logger.Info(date, message);
            }
            else if (loggerMethodType == "FATAL")
            {
                logger.Info(date, message);
            }
        }

        private void CreateAppender(string[] inputInfo)
        {
            string appenderType = inputInfo[1];
            string layoutType = inputInfo[2];
            ReportLevel reportLevel = ReportLevel.Info;
            if (inputInfo.Length > 2)
            {
                reportLevel = Enum.Parse<ReportLevel>(inputInfo[3], true);
            }
            ILayout layout = LayoutFactory.CreateLayout(layoutType);
            IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
            appenders.Add(appender);
        }

        private void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }   
        }
    }
}
