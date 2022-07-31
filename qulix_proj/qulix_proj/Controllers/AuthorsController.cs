using Microsoft.AspNetCore.Mvc;
using qulix_data.Data;
using qulix_repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace qulix_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        
        public AuthorsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _unitOfWork.Authors.GetAll().ToList();
        }
    }
}
