using System.Net;

namespace StockControl.Exception
{
    public class ErrorOnValidationException : StockControlExceptionBase
    {
        private readonly List<string> _Errors;

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public ErrorOnValidationException(List<string> errors) : base(string.Empty)
        {
            _Errors = errors;
        }

        public override List<string> GetErrors()
        {
            return _Errors;
        }
    }
}
