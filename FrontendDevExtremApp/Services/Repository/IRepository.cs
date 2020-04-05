using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IRepository
    {
        Task<bool> addRequestCookie(string cookie);
    }
}
