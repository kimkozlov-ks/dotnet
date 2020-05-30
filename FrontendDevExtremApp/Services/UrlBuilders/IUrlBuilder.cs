using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUrlBuilder
    {
        Uri makeUrl(string componentSettings);
    }
}
