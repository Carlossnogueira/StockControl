namespace StockControl.Domain.Repositories
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
