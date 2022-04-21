using SmartPoles.Domain.Entities;

namespace SmartPoles.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public string GetToken(User user);
        public string GenerateSaltedHash(string plainText, string salt);
        public bool IsHashValid(string value, string salt, string hash);
    }
}
