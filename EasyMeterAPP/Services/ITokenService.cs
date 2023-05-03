using EasyMeterAPP.DTO;

namespace EasyMeterAPP.Services
{
    public interface ITokenService
    {
        string GerarToken(string key, string issuer, UserDTO user);
    }
}
