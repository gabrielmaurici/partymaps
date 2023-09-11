using Microsoft.EntityFrameworkCore;
using src.Domain.Entities;

namespace src.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;
    }
}