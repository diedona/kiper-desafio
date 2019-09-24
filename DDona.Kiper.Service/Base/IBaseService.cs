using DDona.Kiper.Domain.DomainDefinition;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DDona.Kiper.Service.Base
{
    public interface IBaseService<T> where T: class, IBaseEntity
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Exists(Expression<Func<T, bool>> condition);
    }
}