namespace StockControl.Domain
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
