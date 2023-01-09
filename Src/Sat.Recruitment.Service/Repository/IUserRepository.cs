using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Service.Repository.Base;

namespace Sat.Recruitment.Service.Repository
{
    public interface IUserRepository: ISelectableRepository<User>, IInsertableRepository<User>
    {
    }
}
