using System;
using System.Net;

namespace StockControl.Exception.Item;

public class ItemNotFoundException : StockControlExceptionBase
{

    private readonly List<string> _Errors;

    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public ItemNotFoundException() : base(string.Empty)
    {
        _Errors = ["O item não foi encontrado."];
    }

    public override List<string> GetErrors()
    {
        return _Errors;
    }
}
