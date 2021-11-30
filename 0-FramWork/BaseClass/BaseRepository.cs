using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _0_FramWork.BaseClass
{
    public class BaseRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public bool Exsists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }
        public List<T> GetAllList()
        {
            return _context.Set<T>().ToList();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
