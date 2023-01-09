using System;
using AutoMapper;
using System.Threading.Tasks;
using Sat.Recruitment.Service.Dto;
using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Service.Interface;
using Sat.Recruitment.Service.Repository;
using Sat.Recruitment.Service.CustomException;
using Sat.Recruitment.Service.Strategy.UserMoney;

namespace Sat.Recruitment.Service.Implementation
{
    public class UserService: IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly UserMoneyContext userMoneyContext = new UserMoneyContext();

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task AddUser(UserDto user)
        {
            var newUser = mapper.Map<User>(user);
            newUser.Money = GetMoney(newUser);

            NormalizeEmail(newUser);

            if (await userRepository.Exists(x => x.Email == newUser.Email || x.Phone == newUser.Phone))
                throw new UserDuplicatedException();

            if (await userRepository.Exists(x => x.Name == newUser.Name && x.Address == newUser.Address))
                throw new UserDuplicatedException();

            await userRepository.Ins(newUser);
        }

        private decimal GetMoney(User user)
        {
            switch(user.UserType)
            {
                case UserType.SuperUser:
                    userMoneyContext.SetStrategy(new UserSuperStrategy());
                    break;
                case UserType.Premium:
                    userMoneyContext.SetStrategy(new UserPremiumStrategy());
                    break;
                default:
                    userMoneyContext.SetStrategy(new UserNormalStrategy());
                    break;
            }
            return userMoneyContext.ExecuteStrategy(user);
        }

        private void NormalizeEmail(User user)
        {
            var aux = user.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            user.Email = string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
