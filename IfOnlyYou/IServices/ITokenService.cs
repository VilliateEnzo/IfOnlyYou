using IfOnlyYouDataAccessLibrary.Models;

namespace IfOnlyYou.IServices
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
