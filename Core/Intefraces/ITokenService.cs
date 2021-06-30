using Core.Entities.Identity;

namespace Core.Intefraces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}