using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qulix_data.Data.Maps
{
    public class PhotoMap
    {
        public PhotoMap(EntityTypeBuilder<Photo> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.Id);
            entityTypeBuilder.Property(p => p.Name).IsRequired();
            entityTypeBuilder.Property(p => p.Link).IsRequired();
            entityTypeBuilder.Property(p => p.CreatedAt).IsRequired();
            entityTypeBuilder.Property(p => p.Cost).IsRequired();
            entityTypeBuilder.Property(p => p.NumberOfSales).IsRequired();
            entityTypeBuilder.Property(p => p.Rating).IsRequired();
            entityTypeBuilder.Property(p => p.Image).IsRequired();
            entityTypeBuilder.HasOne(p => p.Author).WithMany(p => p.Photo).HasForeignKey(x => x.AuthorId);
        }
    }
}
