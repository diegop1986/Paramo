using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Service.Repository.Base
{
    public interface ISelectableRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAll();

        Task<TEntity> Get(int id);

        Task<TEntity> Get(Func<TEntity, bool> predicate);

        Task<IEnumerable<TEntity>> GetMany(Func<TEntity, bool> predicate);

        Task<bool> Exists(Func<TEntity, bool> predicate);
    }
}
