using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Repository.Base
{
    public interface IInsertableRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> Ins(TEntity entity);
    }
}
