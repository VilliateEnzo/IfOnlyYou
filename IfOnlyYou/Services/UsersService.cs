using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.Data;
using IfOnlyYouDataAccessLibrary.DTOs;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace IfOnlyYou.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UsersService(DataContext repository, IMapper mapper)
        {
            _dataContext = repository;
            _mapper = mapper;
        }

        public async Task<AppUser> GetUserAsync(int id)
        {
            var user = await _dataContext.Users
                .FindAsync(id);

            if (user == null)
            {
                throw new CustomAttributeFormatException("there is no user with that id");
            }

            return user;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            var users = await _dataContext.Users.ToListAsync();

            if (users.Count == 0)
            {
                throw new CustomAttributeFormatException("there is no users");
            }

            return users;
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            var users = await _dataContext.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (users.Count == 0)
            {
                throw new CustomAttributeFormatException("there is no users");
            }

            return users;

        }

        public async Task<bool> UserExistByUsernameAsync(string username)
        {
            return await _dataContext.Users.AnyAsync(u => u.UserName == username);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            var user = await _dataContext.Users
                .Include(u => u.Photos)
                .SingleOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                throw new CustomAttributeFormatException("there is no user with that username");
            }

            return user;
        }


        public async Task<MemberDto> GetMemberByUsernameAsync(string username)
        {
            var user = await _dataContext.Users
                .Where(u => u.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            if (user == null)
            {
                throw new CustomAttributeFormatException("there is no user with that username");
            }

            return user;
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            var user = await _dataContext.Users
                .Where(u => u.Id == id)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            if (user == null)
            {
                throw new CustomAttributeFormatException("there is no user with that id");
            }

            return user;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _dataContext.Entry(user).State = EntityState.Modified;
        }

        public async Task<bool> UpdateUser(MemberUpdateDto memberUpdateDto, string username)
        {
            var user = await GetUserByUsernameAsync(username);
            _mapper.Map(memberUpdateDto, user);

            _dataContext.Update(user);

            return await SaveAllAsync();
        }
    }
}
