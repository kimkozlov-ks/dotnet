using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataModel
{
    public class ComponentSettings
    {
        public bool IsPhone;
        public bool IsGender;
        public bool IsCity;
        public bool IsStreet;
        public bool IsEmail;

        public ComponentSettings(string componentSettings)
        {
            if(componentSettings != null)
            {
                IsPhone = componentSettings.Contains("Phone");
                IsGender = componentSettings.Contains("Gender");
                IsCity = componentSettings.Contains("City");
                IsStreet = componentSettings.Contains("Street");
                IsEmail = componentSettings.Contains("Email");
            }
        }
    }
}
