using Xunit;
using System;
using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Service.Strategy.UserMoney;

namespace Sat.Recruitment.Test.Sat.Recruitment.Service.Strategy
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserMoneyContextTest
    {
        [Fact]
        public void StrategyNotSetTest()
        {
            var context = new UserMoneyContext();
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };
            Assert.Throws<NotImplementedException>(() => context.ExecuteStrategy(user));
        }
    }
}
