
using DBGestorsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DBGestorsApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<DbGestorsModel> gestors { get; set; }
    }
}