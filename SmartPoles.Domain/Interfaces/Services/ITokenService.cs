using SmartPoles.Domain.Entities;

namespace SmartPoles.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public string GetToken(User user);
    }
}
