using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Services
{
    public interface IDataLoader
    {
        void AddSettings(string componentSettings);
        List<User> GetData();

        Task<List<User>> GetDataFromApiAsync();
    }
}
