using System;
using System.Net;

namespace StockControl.Exception.Category;

public class CategoryAlreadyExistsException : StockControlExceptionBase
{

    private readonly List<string> _Errors;

        public override int StatusCode => (int)HttpStatusCode.Conflict;
        public CategoryAlreadyExistsException() : base(string.Empty)
        {
            _Errors = ["Category with the same name already exists."]  ;
        }

        public override List<string> GetErrors()
        {
            return _Errors;
        }
}
