using src.Domain.Dto;
using src.Domain.Entities;

namespace src.Domain.Services
{
    public interface IEventService
    {
        public Task<Event> Post(PostEventDto model);
        Task<List<Event>> GetList();
    }
}