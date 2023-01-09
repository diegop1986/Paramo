using FluentValidation;

namespace Sat.Recruitment.Service.Validation
{
    public class BaseValidator<T> : AbstractValidator<T>
        where T : class
    {
        public string RequiredMessage => "{PropertyName} is required";
    }
}
