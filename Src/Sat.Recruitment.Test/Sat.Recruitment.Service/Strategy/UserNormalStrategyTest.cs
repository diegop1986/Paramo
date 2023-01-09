using Xunit;
using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Service.Strategy.UserMoney;

namespace Sat.Recruitment.Test.Sat.Recruitment.Service.Strategy
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserNormalStrategyTest
    {
        [Fact]
        public void StrategyNormalUserGreaterThan100Test()
        {
            var context = new UserMoneyContext();
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 1000
            };
            context.SetStrategy(new UserNormalStrategy());
            Assert.Equal(1120m, context.ExecuteStrategy(user));
        }

        [Fact]
        public void StrategyNormalUserSmallerThan100Test()
        {
            var context = new UserMoneyContext();
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 20
            };
            context.SetStrategy(new UserNormalStrategy());
            Assert.Equal(36m, context.ExecuteStrategy(user));
        }

        [Fact]
        public void StrategyNormalUserEq100Test()
        {
            var context = new UserMoneyContext();
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 100
            };
            context.SetStrategy(new UserNormalStrategy());
            Assert.Equal(100m, context.ExecuteStrategy(user));
        }

        [Fact]
        public void StrategyNormalUserEq10Test()
        {
            var context = new UserMoneyContext();
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 10
            };
            context.SetStrategy(new UserNormalStrategy());
            Assert.Equal(10m, context.ExecuteStrategy(user));
        }
    }
}
