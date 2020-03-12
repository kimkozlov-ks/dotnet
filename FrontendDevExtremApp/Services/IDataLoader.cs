using System;
using System.Collections.Generic;
using System.Text;
using DataModel;

namespace Services
{
    public interface IDataLoader
    {
        void AddSettings(List<ComponentSettings> componentSettings);
        List<User> GetData();

        List<User> LoadData();
    }
}
