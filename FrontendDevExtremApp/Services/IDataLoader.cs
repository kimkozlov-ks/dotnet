using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Models;

namespace Services
{
    public interface IDataLoader
    {
        void AddSettings(string componentSettings);
        List<User> GetData();

        Task<List<User>> GetDataFromApiAsync();
    }
}
