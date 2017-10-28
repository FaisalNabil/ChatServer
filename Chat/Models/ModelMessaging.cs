using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ModelMessaging : MessageThread
    {
        public string newMessage { get; set; }
        public int ReceiverId { get; set; }
        public IEnumerable<Message> MessagesList { get; set; }
    }
}