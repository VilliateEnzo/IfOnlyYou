using IfOnlyYouDataAccessLibrary.DTOs;
using IfOnlyYouDataAccessLibrary.Models;

namespace IfOnlyYou.IServices
{
    public interface IUsersService
    {
        Task<AppUser> GetUserAsync(int id);
        Task<MemberDto> GetMemberByIdAsync(int id);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
        Task<bool> UserExistByUsernameAsync(string username);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<MemberDto> GetMemberByUsernameAsync(string username);
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
    }
}
