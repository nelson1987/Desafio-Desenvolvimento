using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
            where TEntity : class
    {
        void Insert(TEntity t);
        void Update(TEntity t);
        void Delete(TEntity t);
        List<TEntity> FindAll();
        List<TEntity> FindAll(Func<TEntity, bool> expression);
        TEntity FindById(Guid id);
        TEntity Find(Func<TEntity, bool> expression);
        int Count();
        int Count(Func<TEntity, bool> expression);
    }
}
