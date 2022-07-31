using qulix_data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qulix_repo.Interfaces
{
    public interface ITRepository : IRepository<Text>
    {
        void Add(Text text);
        void SaveInCsv(IEnumerable<Text> text, string filepath);
    }
}
