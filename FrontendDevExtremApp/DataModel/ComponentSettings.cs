using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataModel
{
    public class ComponentSettings
    {
        public string Id;

        public bool IsChecked;

        public ComponentSettings(string id, bool isChecked = false)
        {
            Id = id;
            IsChecked = isChecked;
        }
    }
}
