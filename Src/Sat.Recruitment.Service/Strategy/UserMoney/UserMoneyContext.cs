using System;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Strategy.UserMoney
{
    public class UserMoneyContext
    {
        private IUserMoneyStrategy _strategy;

        public void SetStrategy(IUserMoneyStrategy strategy) => _strategy = strategy;

        public decimal ExecuteStrategy(User user)
        {
            if (_strategy is null) throw new NotImplementedException("Strategy not set");
            return _strategy.GetMoney(user);
        }
    }
}
