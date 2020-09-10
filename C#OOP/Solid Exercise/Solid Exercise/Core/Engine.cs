using System;
using System.Collections.Generic;
using System.Text;
using Solid_Exercise.Appenders;
using Solid_Exercise.Enums;
using Solid_Exercise.Factories;
using Solid_Exercise.Layouts;
using Solid_Exercise.Loggers;

namespace Solid_Exercise.Core
{
    public class Engine
    {
        private readonly CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                try
                {
                    string[] inputInfo = input.Split(' ');
                    if (input == "END")
                    {
                        commandInterpreter.Read(inputInfo);
                        break;
                    }

                    commandInterpreter.Read(inputInfo);
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            
        }
    }    
}
