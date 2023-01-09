using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Strategy.UserMoney
{
    public interface IUserMoneyStrategy
    {
        decimal GetMoney(User user);
    }
}
