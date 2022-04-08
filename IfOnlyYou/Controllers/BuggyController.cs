using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.Data;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IfOnlyYou.Controllers
{
    public class BuggyController : BasicApiController
    {
        private readonly IBuggyService _buggyService;

        public BuggyController(IBuggyService buggyService)
        {
            _buggyService = buggyService;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var result = _buggyService.GetNotFound();

            if (result == null) return NotFound("Element not found");

            return Ok(result);
        }

        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError()
        {
            var result = _buggyService.GetServerError();
            return result;
        }

        [HttpGet("bad-request")]
        public ActionResult<AppUser> GetBadRequest()
        {
            return BadRequest("A bad request");
        }
    }
}
