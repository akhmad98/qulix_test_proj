using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qulix_data.Data.DTOs
{
    public class BaseDTO
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorName { get; set; }
        public string AuthorNickname { get; set; }
        public double Cost { get; set; }
        public int NumberOfSales { get; set; }
        public int Rating { get; set; }
    }
}
