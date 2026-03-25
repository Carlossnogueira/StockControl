using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Communication.Response
{
    public class ErrorResponse
    {
        public List<string> ErrorMessages { get; set; }

        public ErrorResponse(string errorMessage)
        {
            ErrorMessages = [errorMessage];
        }

        public ErrorResponse(List<string> errorMessage)
        {
            ErrorMessages = errorMessage;
        }
    }
}
