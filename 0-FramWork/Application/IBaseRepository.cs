using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_FramWork.Application
{
    public interface IBaseRepository<TKey, T> where T : class
    {
        void Create(T entity);
        bool Exsists(Expression<Func<T, bool>> expression);
        T Get(TKey id);
        List<T> GetAllList();
        void SaveChanges();

    }
}
