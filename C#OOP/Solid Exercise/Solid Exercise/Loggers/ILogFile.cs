using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_Exercise.Loggers
{
    public interface ILogFile
    {
        public int Size { get; }

        void Write(string message);
    }
}
