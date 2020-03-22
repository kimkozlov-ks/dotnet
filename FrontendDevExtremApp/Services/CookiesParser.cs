using System;
using System.Collections.Generic;
using System.Text;
using DataModel;

namespace Services
{
    public class CookiesParser : IParsable<ComponentSettings>
    {
        public IEnumerable<ComponentSettings> parse(string forParse)
        {
            var componentSettings = new List<ComponentSettings>();

            if (forParse != null)
            {
                componentSettings.Add(new ComponentSettings("Phone", Convert.ToBoolean(int.Parse(forParse[0].ToString()))));
                componentSettings.Add(new ComponentSettings("Gender", Convert.ToBoolean(int.Parse(forParse[1].ToString()))));
                componentSettings.Add(new ComponentSettings("Location", Convert.ToBoolean(int.Parse(forParse[2].ToString()))));
                componentSettings.Add(new ComponentSettings("Street", Convert.ToBoolean(int.Parse(forParse[3].ToString()))));
                componentSettings.Add(new ComponentSettings("Email", Convert.ToBoolean(int.Parse(forParse[4].ToString()))));
            }
            else
            {
                componentSettings.Add(new ComponentSettings("Phone"));
                componentSettings.Add(new ComponentSettings("Gender"));
                componentSettings.Add(new ComponentSettings("City"));
                componentSettings.Add(new ComponentSettings("Street"));
                componentSettings.Add(new ComponentSettings("Email"));
            }

            return componentSettings;
        }
    }
}
