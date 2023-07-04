using PartyMaps.Api.src.Data.Dtos;
using src.Data.Entities;
using src.Interfaces.Repositories;
using src.Interfaces.Services;

namespace src.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> Post(PostEventDto model)
        {
            Event entity = new Event(model.IdCreator, model.Name, model.Description, model.EventValue, model.EventDate);

            await _eventRepository.Create(entity);

            return entity;
        }

        public async Task<List<Event>> GetList() => await _eventRepository.GetList();
    }
}