using Microsoft.AspNetCore.SignalR;

namespace PartyMaps.Api.src.Services.Hubs
{
    public class ChatHub : Hub
    {
        public async Task PartyMapsChat(string user, string message, string picture, string userCod, DateTime sendDate, int idEvent)
        {
            Console.WriteLine(idEvent);
            await Clients.All.SendAsync("PartyMapsChat", user, message, picture, userCod, sendDate, idEvent);
        }

        public async Task NotifyTyping(string user, string userCod, int idEvent)
        {
            await Clients.All.SendAsync("NotifyTyping", user, userCod, idEvent);
        }

        public async Task UserEnteringChat(string user, string userCod, int idEvent) 
        {
            await Clients.All.SendAsync("UserEnteringChat", user, userCod, idEvent);
        }
    }
}