using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class RequestDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }

        public RequestDbContext(DbContextOptions<RequestDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}