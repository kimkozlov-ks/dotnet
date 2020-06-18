using Newtonsoft.Json.Linq;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class JsonParser : IParser
    {
        public List<User> parseJTokens(IList<JToken> jTokens)
        {
            List<User> users = new List<User>();

            foreach (var jToken in jTokens)
            {
                var user = createNewUser(jToken);

                users.Add(user);
            }

            return users;
        }

        private User createNewUser(JToken jToken)
        {
            var user = new User();

            if (jToken["phone"] != null)
            {
                user.Phone = Convert.ToString(jToken["phone"]);
            }

            if (jToken["gender"] != null)
            {
                user.Gender = Convert.ToString(jToken["gender"]);
            }

            user.Name = jToken["name"]["first"] + " " + jToken["name"]["last"];

            if (jToken["location"] != null)
            {
                user.City = jToken["location"]["city"].ToString();
                user.Street = jToken["location"]["street"]["number"] + " " + jToken["location"]["street"]["name"];
            }

            if (jToken["email"] != null)
            {
                user.Email = jToken["email"].ToString();
            }

            if (jToken["picture"] != null)
            {
                user.Picture = jToken["picture"]["thumbnail"].ToString();
            }

            return user;
        }
    }
}
