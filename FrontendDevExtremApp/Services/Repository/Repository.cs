using Dapper;
using Database;
using DataModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class Repository : IRepository
    {
        private readonly RequestDbContext _requestDbContext;

        public Repository(RequestDbContext requestDbContext)
        {
            _requestDbContext = requestDbContext;
        }

        public async Task<bool> AddRequestCookie(string cookie)
        {
            await _requestDbContext.Requests.AddAsync(new Request { Cookie = cookie, Time = DateTime.UtcNow });
            await _requestDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Request>> GetRequestCookies()
        {
            string connectionString = "Data Source=test.db";

            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                return await db.QueryAsync<Request>("SELECT * FROM Requests");
            }

            throw new Exception("Failed to GetRequestCookies!");
        }
    }
}
