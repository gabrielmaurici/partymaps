using Microsoft.AspNetCore.Mvc;
using src.Domain.Dto;
using src.Domain.Services;

namespace PartyMaps.Api.src.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IChatService _chatService;

    public EventsController(IEventService eventService, IChatService chatService)
    {
        _eventService = eventService;
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(PostEventDto model) 
    {
        return Ok(await _eventService.Post(model));    
    }    
    
    [HttpGet("list")]
    public async Task<IActionResult> Get() 
    {
        return Ok(await _eventService.GetList());    
    }
}