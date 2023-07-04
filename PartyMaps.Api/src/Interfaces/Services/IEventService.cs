using PartyMaps.Api.src.Data.Dtos;
using src.Data.Entities;

namespace src.Interfaces.Services
{
    public interface IEventService
    {
        public Task<Event> Post(PostEventDto model);
        Task<List<Event>> GetList();
    }
}