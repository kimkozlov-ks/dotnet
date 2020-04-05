using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Database
{
    public class RequestContextFactory : IDesignTimeDbContextFactory<RequestDbContext>
    {
        public RequestDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RequestDbContext>();
            optionsBuilder.UseSqlite("Data Source=test.db");

            return new RequestDbContext(optionsBuilder.Options);
        }
    }
}
