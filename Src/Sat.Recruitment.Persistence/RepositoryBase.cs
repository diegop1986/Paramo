using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Persistence
{
    public abstract class RepositoryBase<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly List<TEntity> Source = new List<TEntity>();

        public abstract Task FillSource();

        public async Task Del(TEntity entity) => await Task.Factory.StartNew((Action)(() => Source.Remove(entity)));

        public async Task Del(int id) => await Task.Factory.StartNew(() => 
        {
            var element = Source.Where(x => x.Id == id).FirstOrDefault();
            if (element is null) throw new Exception("Element doesn't exist");
            Source.Remove(element);
        });

        public async Task<bool> Exists(Func<TEntity, bool> predicate) => await Task.Factory.StartNew(() => Source.Any(predicate));

        public async Task<TEntity> Get(int id) => await Task.Factory.StartNew(() => Source.FirstOrDefault(x => x.Id == id));

        public async Task<TEntity> Get(Func<TEntity, bool> predicate) => await Task.Factory.StartNew(() => Source.FirstOrDefault(predicate));

        public async Task<IList<TEntity>> GetAll() => await Task.Factory.StartNew(() => Source);

        public async Task<IEnumerable<TEntity>> GetMany(Func<TEntity, bool> predicate) => await Task.Factory.StartNew(() => Source.Where(predicate));

        public async Task<TEntity> Ins(TEntity entity) => await Task.Factory.StartNew(() =>
        {
            Source.Add(entity);
            return entity;
        });

        public async Task Upd(TEntity entity) => await Task.Factory.StartNew(() =>
        {
            var element = Source.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (element is null) throw new Exception("Element doesn't exist");
            Source.Remove(element);
            Source.Add(entity);
        });
    }
}
