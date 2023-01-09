using System.Threading.Tasks;
using Sat.Recruitment.Service.Dto;

namespace Sat.Recruitment.Service.Interface
{
    public interface IUserService
    {
        Task AddUser(UserDto user);
    }
}
