using System;
using Solid_Exercise.Appenders;
using Solid_Exercise.Core;
using Solid_Exercise.Enums;
using Solid_Exercise.Layouts;
using Solid_Exercise.Loggers;

namespace Solid_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
