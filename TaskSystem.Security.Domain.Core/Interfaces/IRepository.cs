using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Security.Domain.Core.Models;

namespace Security.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Insert(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}
