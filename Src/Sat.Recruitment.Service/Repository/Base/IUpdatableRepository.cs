using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Repository.Base
{
    public interface IUpdatableRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task Upd(TEntity entity);
    }
}
