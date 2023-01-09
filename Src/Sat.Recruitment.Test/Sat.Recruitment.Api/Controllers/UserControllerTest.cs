using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using Sat.Recruitment.Service.Dto;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Service.Interface;
using Sat.Recruitment.Service.CustomException;

namespace Sat.Recruitment.Test.Sat.Recruitment.Api.Controllers
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTest
    {
        [Fact]
        public async Task AddUserOkTest()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.AddUser(It.IsAny<UserDto>()));
            var userService = userServiceMock.Object;
            var user = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var userController = new UsersController(userService);
            var result = await userController.CreateUser(user);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task AddUserDuplicatedTest()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.AddUser(It.IsAny<UserDto>())).ThrowsAsync(new UserDuplicatedException());
            var userService = userServiceMock.Object;
            var user = new UserDto
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var userController = new UsersController(userService);

            await Assert.ThrowsAsync<UserDuplicatedException>(async () => await userController.CreateUser(user));
        }

        [Fact]
        public async Task AddUserServerErrorTest()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.AddUser(It.IsAny<UserDto>())).ThrowsAsync(new Exception());
            var userService = userServiceMock.Object;
            var user = new UserDto
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var userController = new UsersController(userService);

            await Assert.ThrowsAsync<Exception>(async () => await userController.CreateUser(user));
        }
    }
}
