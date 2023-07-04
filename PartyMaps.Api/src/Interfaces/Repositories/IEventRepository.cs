using src.Data.Entities;

namespace src.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task Create(Event entity);
        
        Task<List<Event>> GetList();
    }
}