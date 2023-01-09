using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Strategy.UserMoney
{
    public class UserSuperStrategy: IUserMoneyStrategy
    {
        public decimal GetMoney(User user)
        {
            if (user.Money > 100)
            {
                var percentage = 0.20m;
                var gif = user.Money * percentage;
                return user.Money + gif;
            }

            return user.Money;
        }
    }
}
