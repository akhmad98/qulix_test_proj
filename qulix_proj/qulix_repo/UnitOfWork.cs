using qulix_repo.Interfaces;
using qulix_data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qulix_repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Authors = new Repository<Author>(_context);
            Texts = new TextRepository(_context);
            Photos = new PhotoRepository(_context);
        }

        public IRepository<Author> Authors { get; private set; }
        public IPRepository Photos { get; private set; }
        public ITRepository Texts { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
