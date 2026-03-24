namespace StockControl.Domain
{
    public interface UnityOfWork
    {
        Task Commit();
    }
}
