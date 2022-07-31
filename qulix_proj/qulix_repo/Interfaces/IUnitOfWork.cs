using qulix_data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qulix_repo.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author> Authors { get; }
        IPRepository Photos { get; }
        ITRepository Texts { get; }
        int Complete();
    }
}
