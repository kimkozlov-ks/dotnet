using Database;
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

        public async Task<bool> addRequestCookie(string cookie)
        {
            await _requestDbContext.Requests.AddAsync(new Request { Cookie = cookie });
            await _requestDbContext.SaveChangesAsync();

            return true;
        }
    }
}
