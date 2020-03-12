using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataModel
{
    public class ComponentSettings
    {
        private string _id;
        public string Id 
        { 
            get => _id; 
            set
            {
                _id = value.Replace("#checkbox", "");
            }
        }
        
        public bool IsChecked { get; set; }
    }
}
