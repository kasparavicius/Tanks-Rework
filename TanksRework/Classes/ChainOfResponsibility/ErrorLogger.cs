using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TanksRework.Classes.ChainOfResponsibility
{
    class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }
        protected override void write(string message)
        {
            Label temp = Application.OpenForms["Form1"].Controls["label5"] as Label;
            temp.Text = "ERROR: " + message;
        }
    }
}
