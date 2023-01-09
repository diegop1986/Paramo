using FluentValidation;
using Sat.Recruitment.Service.Dto;
using Sat.Recruitment.Domain.Enum;

namespace Sat.Recruitment.Service.Validation
{
    public class UserDtoValidator : BaseValidator<UserDto>
    {
        public UserDtoValidator() : base()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.Email).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.Address).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.Phone).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.UserType).IsEnumName(typeof(UserType), caseSensitive: false);
        }
    }
}
