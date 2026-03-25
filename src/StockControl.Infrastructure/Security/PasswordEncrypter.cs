using StockControl.Domain.Security;
using BC = BCrypt.Net.BCrypt;

namespace StockControl.Infrastructure.Security
{
    internal class PasswordEncrypter : IPasswordEncrypter
    {
        public string EncryptPassword(string password)
        {
            string passwordHash = BC.HashPassword(password);
            return passwordHash;
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            bool isValid = BC.Verify(password, passwordHash);
            return isValid;
        }
    }
}
