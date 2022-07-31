using Microsoft.EntityFrameworkCore;
using qulix_data.Data;
using qulix_data.Data.Maps;

namespace qulix_repo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AuthorMap(modelBuilder.Entity<Author>());
            new PhotoMap(modelBuilder.Entity<Photo>());
            new TextMap(modelBuilder.Entity<Text>());
        }
    }
}