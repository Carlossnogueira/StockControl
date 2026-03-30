using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Communication.Response
{
    public class SuccessResponse
    {
        public SuccessResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; } = string.Empty;
    }
}
