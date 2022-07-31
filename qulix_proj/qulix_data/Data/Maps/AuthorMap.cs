using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qulix_data.Data.Maps
{
    public class AuthorMap
    {
        public AuthorMap(EntityTypeBuilder<Author> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.Id);
            entityTypeBuilder.Property(p => p.FirstName).IsRequired();
            entityTypeBuilder.Property(p => p.LastName).IsRequired();
            entityTypeBuilder.Property(p => p.Nickname).IsRequired();
            entityTypeBuilder.Property(p => p.DateOfBirth).IsRequired();
            entityTypeBuilder.Property(p => p.DateOfRegistr).IsRequired();
        }
    }
}
