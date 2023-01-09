using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Strategy.UserMoney
{
    public class UserNormalStrategy: IUserMoneyStrategy
    {
        public decimal GetMoney(User user)
        {
            if (user.Money > 100)
            {
                var percentage = 0.12m;
                //If new user is normal and has more than USD100
                var gif = user.Money * percentage;
                return user.Money + gif;
            }
            if (user.Money < 100)
            {
                if (user.Money > 10)
                {
                    var percentage = 0.8m;
                    var gif = user.Money * percentage;
                    return user.Money + gif;
                }
            }

            return user.Money;
        }
    }
}
