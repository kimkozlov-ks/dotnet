using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class RandomUserUrlBuilder : IUrlBuilder
    {
        public Uri makeUrl(string componentSettings)
        {
            string url = "https://randomuser.me/api/?inc=name,picture";

            if (componentSettings != null)
            {
                var editedComopentSettingsString = componentSettings.ToLower().Replace('_', ',');

                if (editedComopentSettingsString.Contains("city,street"))
                {
                    editedComopentSettingsString = editedComopentSettingsString.Replace("city,street", "location");
                }
                else if (editedComopentSettingsString.Contains("city"))
                {
                    editedComopentSettingsString = editedComopentSettingsString.Replace("city", "location");
                }
                else if (editedComopentSettingsString.Contains("street"))
                {
                    editedComopentSettingsString = editedComopentSettingsString.Replace("street", "location");
                }

                url += ',' + editedComopentSettingsString;
            }

            url += "&seed=foobar&results=100&noinfo";

            if (url.Contains("&gender=male"))
            {
                url.Replace("&gender=male", "");
            }
            else if (url.Contains("&gender=female"))
            {
                url.Replace("&gender=female", "");
            }

            return new Uri(url);
        }
    }
}
