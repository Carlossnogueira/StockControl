using System;
using System.Net;

namespace StockControl.Exception.Category;

public class CategoryNotFoundException : StockControlExceptionBase
{

     private readonly List<string> _Errors;

        public override int StatusCode => (int)HttpStatusCode.UnprocessableEntity;
        public CategoryNotFoundException() : base(string.Empty)
        {
            _Errors = ["A categoria não foi encontrada."]  ;
        }

        public override List<string> GetErrors()
        {
            return _Errors;
        }

}
