using Microsoft.AspNetCore.Mvc;
using src.Domain.Services;

namespace PartyMaps.Api.src.Controllers;

[ApiController]
[Route("api/chats")]
public class ChatsController : ControllerBase 
{
    private readonly IChatService _chatService;

    public ChatsController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int take, [FromQuery] int limit) 
    {
        return Ok(_chatService.Get(take, limit));    
    }
}