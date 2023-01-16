﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace ProiectMPA_1.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }
    }
}
