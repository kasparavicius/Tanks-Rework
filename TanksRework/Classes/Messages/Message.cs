using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiRework.Classes.Messages
{
    public class Message
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string message { get; set; }

        public Message()
        {

        }
        
        public Message(string id, string name, string message)
        {
            this._id = id;
            this.name = name;
            this.message = message;
        }
    }
}
