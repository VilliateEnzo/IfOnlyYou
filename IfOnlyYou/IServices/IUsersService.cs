using IfOnlyYouDataAccessLibrary.Models;

namespace IfOnlyYou.IServices
{
    public interface IUsersService
    {
        Task<AppUser> GetUser(int id);
        Task<IEnumerable<AppUser>> GetAllUsers();
    }
}
