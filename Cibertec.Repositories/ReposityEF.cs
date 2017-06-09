﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cibertec.Repositories
{
    public class ReposityEF<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public ReposityEF(DbContext context)
        {
            _context = context;
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public int Insert(T entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();

        }

        public bool Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
