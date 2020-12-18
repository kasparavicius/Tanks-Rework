using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.ChainOfResponsibility
{
    abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int FILE = 2;
        public static int ERROR = 3;

        protected int level;

        protected AbstractLogger nextLogger;

        public void setNextLogger(AbstractLogger nextLog)
        {
            nextLogger = nextLog;
        }

        public void logMessage(int level, string message)
        {
            if(this.level <= level)
            {
                write(message);
            }
            if (nextLogger != null)
            {
                nextLogger.logMessage(level, message);
            }
        }

        abstract protected void write(string message);
    }
}
