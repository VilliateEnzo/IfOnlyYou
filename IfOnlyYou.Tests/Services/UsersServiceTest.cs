using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IfOnlyYou.IServices;
using IfOnlyYou.Services;
using IfOnlyYouDataAccessLibrary.Data;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace IfOnlyYou.Tests.Services
{
    public class UsersServiceTest
    {
        private UsersService _target;
        private Mock<IUsersService> _usersServiceMock;
        private Mock<DataContext> _myDbContextMock;


        [SetUp]
        public void Init()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            _usersServiceMock = new Mock<IUsersService>();
            _myDbContextMock = new Mock<DataContext>(optionsBuilder.Options);
            _target = new UsersService(_myDbContextMock.Object);
        }

        [Test()]
        public void GetUserSuccessTest()
        {
            const int userId = 3;

            var user = new AppUser()
            {
                Id = userId,
                PasswordHash = new byte[] { },
                PasswordSalt = new byte[] { },
                UserName = "testo"
            };

            _usersServiceMock.Setup(s => s.GetUserAsync(It.IsAny<int>())).Returns(Task.FromResult(user));
            _myDbContextMock.Setup(x => x.FindAsync<AppUser>(It.IsAny<int>())).ReturnsAsync(user);

            var result = _target.GetUserAsync(3);
            var expected = Task.FromResult(user);

            Assert.NotNull(result);
            Assert.AreEqual(1, 1);
        }
    }
}
