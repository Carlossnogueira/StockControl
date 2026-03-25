using System.Net;

namespace StockControl.Exception.User
{
    public class UserAlreadyExistsException : StockControlExceptionBase
    {

        private readonly List<string> _Errors;

        public override int StatusCode => (int)HttpStatusCode.BadRequest;
        public UserAlreadyExistsException() : base(string.Empty)
        {
            _Errors = ["Falha ao realizar o login, verifique o login e a senha"];
        }

        public override List<string> GetErrors()
        {
            return _Errors;
        }
    }
}
