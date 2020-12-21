using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiRework.Classes.Messages
{
    class InsultingExpressions : AbstractExpression
    {
        public void Evaluate(Message message)
        {
            string expression = message.message;
            message.message = expression.Replace("NOOB", "****");
        }
    }
}
