using Microsoft.AspNetCore.SignalR;
using src.Domain.Dto;
using src.Domain.Services;

namespace PartyMaps.Api.src.Services.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task PartyMapsChat(ChatDto model)
        {
            await _chatService.Save(model);
            await Clients.All.SendAsync("PartyMapsChat", model);
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