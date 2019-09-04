using Desafio.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Repository.Repositories
{
    public abstract class BaseRepository<TEntity> :
        IBaseRepository<TEntity>
where TEntity : class
    {
        private readonly DesafioContext context;
        //construtor com entrada de argumentos
        public BaseRepository(DesafioContext context)
        {
            this.context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Func<TEntity, bool> expression)
        {
            throw new NotImplementedException();
        }

        public void Create(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }
        public void Delete(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public TEntity Find(Func<TEntity, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public List<TEntity> FindAll(Func<TEntity, bool> expression)
        {
            return context.Set<TEntity>().Where(expression).ToList();
        }

        public TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity FindById(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity t)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}