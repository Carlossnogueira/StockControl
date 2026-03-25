using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Exception.User
{
    public class UserUnauthorizedException : StockControlExceptionBase
    {

        private readonly List<string> _Errors;

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;
        public UserUnauthorizedException() : base(string.Empty)
        {
            _Errors = ["Usuário não autorizado"];
        }

        public override List<string> GetErrors()
        {
            return _Errors;
        }
    }
}
