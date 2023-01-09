using Sat.Recruitment.Domain.Enum;

namespace Sat.Recruitment.Domain.Extensions
{
    public static class UserTypeExtension
    {
        public static UserType ToUserType(this string value) => (UserType)System.Enum.Parse(typeof(UserType), value, true);
    }
}
