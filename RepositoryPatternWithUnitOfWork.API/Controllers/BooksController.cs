using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;

namespace RepositoryPatternWithUnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _repository;

        public BooksController(IBaseRepository<Book> repository)
        {
            _repository = repository;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_repository.GetAll());


        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {

            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var getById = _repository.GetById(id);
            return Ok(getById);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {

            return Ok(await _repository.GetByIdAsync(id));
        }


        [HttpGet("GetByName")]
        public IActionResult GetByName(string Name)
        {

            return Ok(_repository.Find(x => x.Title == Name, new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthor")]
        public IActionResult GetAllWithAuthor(string Name)
        {
            var getList = _repository.FindAll(x => x.Author.Name.Contains(Name), new[] { "Author" });
            return Ok(getList);
        }

    }
}
