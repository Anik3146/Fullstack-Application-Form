using Microsoft.EntityFrameworkCore;
using ServerSide.API.Models;

namespace ServerSide.API.Data
{
    public class ServerSideDbContext : DbContext
    {
        public ServerSideDbContext(DbContextOptions options) : base(options) {
        
        
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
