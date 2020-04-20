using DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IRepository
    {
        Task<bool> AddRequestCookie(string cookie);
        Task<IEnumerable<Request>> GetRequestCookies();
    }
}
