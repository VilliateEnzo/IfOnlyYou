﻿using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.Data;
using IfOnlyYouDataAccessLibrary.DTOs;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace IfOnlyYou.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITokenService _tokenService;
        private readonly DataContext _dataContext;

        public AccountService(DataContext repository, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _dataContext = repository;
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Username))
            {
                throw new CustomAttributeFormatException("Username is taken.");
            }

            var user = HashPassword(registerDto);

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new UserDto()
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.username);

            if (user == null)
            {
                throw new CustomAttributeFormatException("Invalid username");
            }

            if (!PasswordMatch(user, loginDto.password))
            {
                throw new CustomAttributeFormatException("Invalid password");
            }

            return new UserDto()
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private static bool PasswordMatch(AppUser appUser, string passwordLogin)
        {
            using var hmac = new HMACSHA512(appUser.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordLogin));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != appUser.PasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static AppUser HashPassword(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser()
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            return user;
        }

        private async Task<bool> UserExist(string username)
        {
            return await _dataContext.Users.AnyAsync(u => u.UserName == username);
        }

    }
}