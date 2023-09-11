using src.Domain.Entities;

namespace src.Domain.Repositories
{
    public interface IEventRepository
    {
        Task Create(Event entity);
        
        Task<List<Event>> GetList();
    }
}