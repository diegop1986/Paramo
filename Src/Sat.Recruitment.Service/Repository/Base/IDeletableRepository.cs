using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Repository.Base
{
    public interface IDeletableRepository<TEntity>
        where TEntity: BaseEntity
    {
        Task Del(TEntity entity);

        Task Del(int id);
    }
}
