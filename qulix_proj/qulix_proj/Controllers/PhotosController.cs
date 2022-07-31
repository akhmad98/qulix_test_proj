using Microsoft.AspNetCore.Mvc;
using qulix_repo;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using qulix_data.Data.DTOs;
using qulix_data.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace qulix_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public PhotosController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<PhotosController>
        [HttpGet]
        public IEnumerable<PhotoDTO> Get()
        {
            IQueryable<PhotoDTO> photoWithDTO = from p in _unitOfWork.Photos.GetAll()
                                                select new PhotoDTO
                                                {
                                                    Name = p.Name,
                                                    Link = p.Link,
                                                    Size = p.Size,
                                                    CreatedAt = p.CreatedAt,
                                                    AuthorName = p.Author.FirstName,
                                                    AuthorNickname = p.Author.Nickname,
                                                    Cost = p.Cost,
                                                    NumberOfSales = p.NumberOfSales,
                                                    Rating = p.Rating,
                                                };

            return photoWithDTO.AsEnumerable<PhotoDTO>();
        }

        // GET api/<PhotosController>/5
        [HttpGet("{id}")]
        public PhotoDTO Get(int id)
        {
            try
            {
                Photo photo = _unitOfWork.Photos.GetById(id);
                var author = _unitOfWork.Authors.GetAll().FirstOrDefault(el => el.Id == photo.AuthorId);
                
                var photoWithDto = new PhotoDTO
                {
                    Name = photo.Name,
                    Link = photo.Link,
                    Size = photo.Size,
                    CreatedAt = photo.CreatedAt,
                    AuthorName = author.FirstName,
                    AuthorNickname = author.Nickname,
                    Cost = photo.Cost,
                    NumberOfSales = photo.NumberOfSales,
                    Rating = photo.Rating,
                };

                return photoWithDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception thrown");
            }
        }

        // POST api/<PhotosController>
        [HttpPost]
        public void Post([FromBody] PhotoDTO value, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            var author = _unitOfWork.Authors.GetAll()
                .FirstOrDefault(el => el.Nickname == value.AuthorNickname);

            string filePath = string.Empty;
            string extension = string.Empty;
            try
            {
                filePath = Path.GetFullPath(Path.Combine(hostingEnvironment.WebRootPath, "photos", "1photo.jpg")); ;

                extension = Path.GetExtension("1photo.jpg");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(ex));
            }

            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            if (ModelState.IsValid)
            {
                var newPhoto = new Photo
                {
                    Name = value.Name,
                    Link = filePath,
                    Size = value.Size,
                    CreatedAt = value.CreatedAt,
                    Author = author,
                    AuthorId = author.Id,
                    Cost = value.Cost,
                    NumberOfSales = value.NumberOfSales,
                    Rating = value.Rating,
                    Image = bytes
                };

                _unitOfWork.Photos.Update(newPhoto);
            }
        }

        // PUT api/<PhotosController>/5
        /// <summary>
        /// Returns nothing
        /// But Rating should be followed the guide provided:
        /// "excellent" => 5,
        /// "good" => 4,
        /// "not bad" => 3,
        /// "bad" => 2,
        /// "poor" => 1,
        /// Any other values will be qualified as zero 0
        /// </summary>
        /// <param name="id">id of photo</param>
        /// <param name="value">string expressions as above</param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var rating = 0;

            switch(value)
            {
                case "excellent":
                    rating = 5;
                    break;
                case "good":
                    rating = 4;
                    break;
                case "not bad":
                    rating = 3;
                    break;
                case "bad":
                    rating = 2;
                    break;
                case "poor":
                    rating = 1;
                    break;
                default:
                    rating = 0;
                    break;
            }

            _unitOfWork.Photos.Rate(id, rating);
        }

        // DELETE api/<PhotosController>/5
        [HttpGet("{id}/rate")]
        public double Calculate(int id)
        {
            return 1.00;
        }
    }
}
