using qulix_data.Data;
using qulix_data.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qulix_repo.Interfaces
{
    public interface IPRepository : IRepository<Photo>
    {
        Photo GetById(int id);
        void Update(Photo photo);
        void Rate(int photoid, int rate);
        double Calculate(ICollection<int> costs);
    }
}
