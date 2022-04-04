using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace IfOnlyYou.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var result = await _usersService.GetUser(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            var result = await _usersService.GetAllUsers();

            return Ok(result);
        }
    }
}
