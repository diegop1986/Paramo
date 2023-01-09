namespace Sat.Recruitment.Service.CustomException
{
    public class UserDuplicatedException: BusinessException
    {
        public UserDuplicatedException(): base("User is duplicated") { }
    }
}
