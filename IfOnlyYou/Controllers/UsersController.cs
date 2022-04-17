using AutoMapper;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.DTOs;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IfOnlyYou.Controllers
{
    [Authorize]
    public class UsersController : BasicApiController
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            return await _usersService.GetMemberByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<MemberDto>> GetAllUsers()
        {
            return await _usersService.GetAllMembersAsync(); ;
        }

        [HttpGet("getMember/{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
        {
            return await _usersService.GetMemberByUsernameAsync(username);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (await _usersService.UpdateUser(memberUpdateDto, username)) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}
