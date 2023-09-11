using Microsoft.EntityFrameworkCore;
using src.Infra.Context;
using src.Domain.Entities;
using src.Domain.Repositories;

namespace src.Infra.Repositories
{
    public class EventRepository : IEventRepository
    {
        public readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Event entity)
        {
            await _context.Events.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Event>> GetList()
        {
            return await _context.Events.OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}