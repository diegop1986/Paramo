using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Service.Dto;
using Sat.Recruitment.Service.Interface;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService) => this.userService = userService;

        [HttpPost]
        [Route("/create-user")]
        public async Task<ResultDto> CreateUser(UserDto user)
        {
            await userService.AddUser(user);
            return new ResultDto { IsSuccess = true };
        }
    }
}
