using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        public void Announce(string message)
        {
            Clients.All.Announce(message);
        }
    }
}