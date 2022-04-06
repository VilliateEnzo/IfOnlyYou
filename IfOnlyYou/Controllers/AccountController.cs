using System.Security.Cryptography;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.DTOs;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace IfOnlyYou.Controllers
{
    public class AccountController : BasicApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var result = await _accountService.Register(registerDto);


            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var result = await _accountService.Login(loginDto);


            return Ok(result);
        }
    }
}
