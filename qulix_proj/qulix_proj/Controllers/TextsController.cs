using Microsoft.AspNetCore.Mvc;
using qulix_repo;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using qulix_data.Data;
using qulix_data.Data.DTOs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace qulix_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextsController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public TextsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TextDTO> Get()
        {
            IQueryable<TextDTO> textsWithDto = from p in _unitOfWork.Texts.GetAll()
                                                select new TextDTO
                                                {
                                                    Name = p.Name,
                                                    Texts = p.Texts,
                                                    CreatedAt = p.CreatedAt,
                                                    AuthorName = p.Author.FirstName,
                                                    AuthorNickname = p.Author.Nickname,
                                                    Cost = p.Cost,
                                                    NumberOfSales = p.NumberOfSales,
                                                    Rating = p.Rating,
                                                };

            return textsWithDto.AsEnumerable<TextDTO>();
        }

        // GET api/<ValuesController>/alltocsv
        [HttpGet]
        [Route("alltocsv")]
        public void GetAllToCsv([FromServices] IHostingEnvironment hostingEnvironment)
        {
            string filepath = string.Empty;
            string extension = string.Empty;

            try
            {
                filepath = Path.GetFullPath(Path.Combine(hostingEnvironment.WebRootPath, "files", "data.csv"));
                extension = Path.GetExtension(filepath);
            } catch (Exception ex)
            {
                throw new ArgumentException(nameof(ex));
            }

            var texts = _unitOfWork.Texts.GetAll().AsEnumerable();

            _unitOfWork.Texts.SaveInCsv(texts, filepath);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] TextDTO value)
        {
            var author = _unitOfWork.Authors.GetAll().FirstOrDefault(el => el.Nickname == value.AuthorNickname);

            if (ModelState.IsValid)
            {
                var newText = new Text
                {
                    Name = value.Name,
                    Texts = value.Texts,
                    CreatedAt = value.CreatedAt,
                    Author = author,
                    AuthorId = author.Id,
                    Cost = value.Cost,
                    NumberOfSales = value.NumberOfSales,
                    Rating = value.Rating,
                };

                _unitOfWork.Texts.Add(newText);
            }
        }
    }
}
