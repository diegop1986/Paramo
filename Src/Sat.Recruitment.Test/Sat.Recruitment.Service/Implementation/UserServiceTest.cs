using Moq;
using Xunit;
using System;
using AutoMapper;
using System.Threading.Tasks;
using Sat.Recruitment.Service.Dto;
using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Service.Repository;
using Sat.Recruitment.Service.Implementation;
using Sat.Recruitment.Service.CustomException;

namespace Sat.Recruitment.Test.Sat.Recruitment.Service.Implementation
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserServiceTest
    {
        [Fact]
        public async Task AddUserOkTest()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Exists(It.IsAny<Func<User, bool>>())).ReturnsAsync(false);
            userRepositoryMock.Setup(x => x.Ins(It.IsAny<User>()));
            var userRepository = userRepositoryMock.Object;
            var userDto = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<User>(It.IsAny<UserDto>())).Returns(user);
            var mapper = mapperMock.Object;

            var userService = new UserService(mapper, userRepository);
            await userService.AddUser(userDto);
        }

        [Fact]
        public async Task AddUserDuplicatedTest()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Exists(It.IsAny<Func<User, bool>>())).ReturnsAsync(true);
            userRepositoryMock.Setup(x => x.Ins(It.IsAny<User>()));
            var userRepository = userRepositoryMock.Object;
            var userDto = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<User>(It.IsAny<UserDto>())).Returns(user);
            var mapper = mapperMock.Object;

            var userService = new UserService(mapper, userRepository);
            await Assert.ThrowsAsync<UserDuplicatedException>(async () => await userService.AddUser(userDto));
        }

        [Fact]
        public async Task AddUserRepositoryErrorTest()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Exists(It.IsAny<Func<User, bool>>())).ReturnsAsync(false);
            userRepositoryMock.Setup(x => x.Ins(It.IsAny<User>())).ThrowsAsync(new Exception());
            var userRepository = userRepositoryMock.Object;
            var userDto = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<User>(It.IsAny<UserDto>())).Returns(user);
            var mapper = mapperMock.Object;

            var userService = new UserService(mapper, userRepository);
            await Assert.ThrowsAsync<Exception>(async () => await userService.AddUser(userDto));
        }
    }
}
