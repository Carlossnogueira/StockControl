namespace StockControl.Domain
{
    public interface IPasswordEncrypter
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
