using StockControl.Communication.Request;
using StockControl.Communication.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Domain.Service
{
    public interface ILoginService
    {
        public Task<JwtTokenResponse> Login(LoginRequest loginRequest);
    }
}
