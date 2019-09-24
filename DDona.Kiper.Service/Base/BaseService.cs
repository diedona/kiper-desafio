using DDona.Kiper.Domain.DomainDefinition;
using DDona.Kiper.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DDona.Kiper.Service.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, IBaseEntity
    {
        protected readonly KiperDesafioContext _db;
        protected DbSet<T> _dbSet => _db.Set<T>();

        public BaseService(KiperDesafioContext db)
        {
            _db = db;
            _db.Set<T>();
        }

        public virtual void Save(T entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T entity = _db.Set<T>().Find(id);
            if (entity == null)
            {
                return;
            }

            entity.Status = false;
            _db.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            entity.Status = false;
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Exists(Expression<Func<T, bool>> condition)
        {
            return _dbSet.Any(condition);
        }
    }
}
