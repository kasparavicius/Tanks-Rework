using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Classes.Messages;

namespace TankaiServer.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message
        public List<Message> Get()
        {

            return (List<Message>)System.Web.HttpContext.Current.Application["messages"] ?? new List<Message>();
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public void Post([FromBody] Message msg)
        {
            List<Message> messages = (List<Message>)System.Web.HttpContext.Current.Application["messages"] ?? new List<Message>();

            messages.Add(msg);
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["messages"] = messages;
            System.Web.HttpContext.Current.Application.UnLock();
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete()
        {
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["messages"] = null;
            System.Web.HttpContext.Current.Application.UnLock();
        }
    }
}
