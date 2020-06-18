using Newtonsoft.Json.Linq;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IParser
    {
        List<User> parseJTokens(IList<JToken> jTokens);
    }
}
