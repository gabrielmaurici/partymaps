using Microsoft.EntityFrameworkCore;
using src.Data.Entities;

namespace src.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Event> Events { get; set; } = null!;
    }
}