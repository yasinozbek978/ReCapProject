using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //generic constraint
        //class : referans tip olabilir
        //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
        //new() : new'lenebilir olamlı
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delet(T entity);
    }
}
