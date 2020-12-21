using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiRework.Classes.Messages
{
    public interface AbstractExpression
    {
        void Evaluate(Message message);
    }
}
