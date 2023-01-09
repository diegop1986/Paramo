using Xunit;
using System.Threading.Tasks;
using Sat.Recruitment.Persistence;
using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Test.Sat.Recruitment.Persistence
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserRepositoryTest
    {
        [Fact]
        public async Task AddUserOkTest()
        {
            var repository = new UserRepository();

            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            var resutl = await repository.Ins(user);
            Assert.NotNull(resutl);
        }

        [Fact]
        public async Task GetAllOkTest()
        {
            var repository = new UserRepository();

            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            await repository.Ins(user);

            var result = await repository.GetAll();
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetOkTest()
        {
            var repository = new UserRepository();

            var user = new User
            {
                Id = 1,
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            await repository.Ins(user);

            var result = await repository.Get(1);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetOk2Test()
        {
            var repository = new UserRepository();

            var user = new User
            {
                Id = 1,
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            await repository.Ins(user);

            var result = await repository.Get(x => x.Id == 1);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetManyOkTest()
        {
            var repository = new UserRepository();

            var user = new User
            {
                Id = 1,
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            await repository.Ins(user);

            var result = await repository.GetMany(x => x.Name == "Mike");
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ExistOkTest()
        {
            var repository = new UserRepository();

            var user = new User
            {
                Id = 1,
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };

            await repository.Ins(user);

            var result = await repository.Exists(x => x.Id == 1);
            Assert.True(result);
        }
    }
}
