using System;
using System.Net;

namespace StockControl.Exception.Category;

public class CategoryAlreadyExistsException : StockControlExceptionBase
{

    private readonly List<string> _Errors;

    public override int StatusCode => (int)HttpStatusCode.Conflict;
    public CategoryAlreadyExistsException() : base(string.Empty)
    {
        _Errors = ["Já existe uma categoria com esse nome."]  ;
    }

    public override List<string> GetErrors()
    {
        return _Errors;
    }
}
