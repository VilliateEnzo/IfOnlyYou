using System.Net;
using System.Reflection;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.Data;
using IfOnlyYouDataAccessLibrary.Errors;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace IfOnlyYou.Services
{
    public class BuggyService : IBuggyService
    {
        private readonly DataContext _dataContext;

        public BuggyService(DataContext repository)
        {
            this._dataContext = repository;
        }

        public AppUser GetNotFound()
        {
            var result = _dataContext.Users.Find(-1);

            return result;
        }

        public AppUser GetServerError()
        {
            var result = _dataContext.Users.Find(-1);
            var resultToReturn = result.ToString();

            return result;
        }
    }
}
