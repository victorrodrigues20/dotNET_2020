using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected BibliotecaDbContext _context;

        public Repository(BibliotecaDbContext context)
        {
            _context = context;
        }

        // using System.Linq.Expressions;
        // using Microsoft.EntityFrameworkCore;
        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        // using System.Linq;
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            // _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            // _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            // _context.SaveChanges();
        }
    }
}
