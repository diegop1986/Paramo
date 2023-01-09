using AutoMapper;
using Sat.Recruitment.Service.Dto;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Domain.Extensions;

namespace Sat.Recruitment.Service.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.UserType,
                opt => opt.MapFrom(src => src.UserType.ToUserType()))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
