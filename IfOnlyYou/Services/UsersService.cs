using System.Reflection;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.Data;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace IfOnlyYou.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;

        public UsersService(DataContext repository)
        {
            this._dataContext = repository;
        }

        public async Task<AppUser> GetUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);

            if (user == null)
            {
                throw new CustomAttributeFormatException("there is no user with that id");
            }

            return user;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            var users = await _dataContext.Users.ToListAsync();

            if (users.Count == 0)
            {
                throw new CustomAttributeFormatException("there is no users");
            }

            return users;
        }
    }
}
