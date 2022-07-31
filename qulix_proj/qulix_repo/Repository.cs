using qulix_data.Data;
using qulix_repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace qulix_repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _entities;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IQueryable<T> GetAll() 
        {
            return _entities.AsQueryable();
        }
    }
}
