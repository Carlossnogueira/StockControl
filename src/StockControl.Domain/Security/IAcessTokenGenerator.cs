using StockControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Domain.Security
{
    public interface IAcessTokenGenerator
    {
        string Generate(User user);
    }
}
