using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Exception
{
    public abstract class StockControlExceptionBase : SystemException
    {
        protected StockControlExceptionBase(string message) : base(message) { }

        public abstract int StatusCode { get; }
        public abstract List<String> GetErrors();
    }
}
