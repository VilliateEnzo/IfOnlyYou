using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace IfOnlyYou.IServices
{
    public interface IBuggyService
    {
        AppUser GetNotFound();
        AppUser GetServerError();
    }
}
