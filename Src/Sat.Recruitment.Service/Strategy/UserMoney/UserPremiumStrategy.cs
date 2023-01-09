using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Strategy.UserMoney
{
    public class UserPremiumStrategy: IUserMoneyStrategy
    {
        public decimal GetMoney(User user)
        {
            if (user.Money > 100)
            {
                var gif = user.Money * 2;
                return user.Money + gif;
            }

            return user.Money;
        }
    }
}
