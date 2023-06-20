using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PartyMaps.Api.src.Services.Hubs
{
    public class ChatHub : Hub
    {
        public async Task PartyMapsChat(string user, string message, string picture, string userCod, DateTime sendDate)
        {
            await Clients.All.SendAsync("PartyMapsChat", user, message, picture, userCod, sendDate);
        }

        public async Task NotifyTyping(string user, string userCod)
        {
            await Clients.All.SendAsync("NotifyTyping", user, userCod);
        }

        public async Task UserEnteringChat(string user, string userCod) 
        {

            await Clients.All.SendAsync("UserEnteringChat", user, userCod);
        }
    }
}