using ITL_MakeId.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ITL_MakeId.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Set => _context.Set<T>();

        public bool Add(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
