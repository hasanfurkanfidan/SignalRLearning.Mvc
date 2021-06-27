using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLearning.Api.Hubs
{
    public class NotificationHub:Hub
    {
        public static List<string> Names { get; set; } = new List<string>();
        public async Task SendMessage(string name)
        {
            Names.Add(name);
            await Clients.All.SendAsync("ReceiveMessage", name);
        }
        public async Task GetMessages()
        {
            await Clients.All.SendAsync("ReceiveMessages", Names);
        }
    }
}
