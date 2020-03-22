using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IParsable<T>
    {
        IEnumerable<T> parse(string forParse);
    }
}
