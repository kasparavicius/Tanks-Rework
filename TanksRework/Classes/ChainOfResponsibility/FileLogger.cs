using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TanksRework.Classes.ChainOfResponsibility
{
    class FileLogger : AbstractLogger
    {
        public FileLogger(int level)
        {
            this.level = level;
        }
        protected override void write(string message)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                string temp = DateTime.Now.ToString() + " FILELOG: " + message;
                w.WriteLine(temp);
            }
        }
    }
}
