using qulix_data.Data;
using qulix_data.Data.DTOs;
using qulix_repo.Interfaces;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace qulix_repo
{
    public class PhotoRepository : Repository<Photo>, IPRepository
    {
        public PhotoRepository(ApplicationContext context) : base(context)
        {
        }

        public Photo GetById(int id)
        {
            var photo = _entities.SingleOrDefault(el => el.Id == id);

            if (photo == null)
            {
                throw new ArgumentException("photo can not be null!");
            }

            return photo;
        }

        public void Update(Photo photo)
        {
            if (photo == null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            _context.ChangeTracker.Clear();
            _entities.Attach(photo);
            _context.Entry(photo).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Rate(int photoid, int rate)
        {
            if (rate < 0 || rate > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(rate));
            }

#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
#pragma warning disable S2583 // Conditionally executed code should be reachable
            if (rate == null)
            {
                throw new ArgumentException($"rate was not supplied");
            }
#pragma warning restore S2583 // Conditionally executed code should be reachable
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'

            var currentPhoto = GetById(photoid);

            var newPhoto = new Photo()
            {
                Id = photoid,
                Name = currentPhoto.Name,
                Link = currentPhoto.Link,
                Size = currentPhoto.Size,
                CreatedAt = currentPhoto.CreatedAt,
                Cost = currentPhoto.Cost,
                NumberOfSales = currentPhoto.NumberOfSales,
                Rating = rate,
            };

            _context.ChangeTracker.Clear();
            _context.Entry(newPhoto).Property(s => s.Rating).IsModified = true;
            _context.SaveChanges();
        }

        public double Calculate(ICollection<int> rates)
        {
            double total = 0;
            foreach (var cost in rates)
            {
                total = total + cost;
            }

            return total / rates.Count;
        }
    }
}
