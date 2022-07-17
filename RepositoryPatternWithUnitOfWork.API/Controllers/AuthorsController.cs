using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.EF.Context;

namespace RepositoryPatternWithUnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _repository;
        private readonly DataContext _context;

        public AuthorsController(IBaseRepository<Author> repository, DataContext context)
        {
            _repository = repository;
            _context = context;
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

            return Ok(_repository.Find(x => x.Name == Name));
        }


    }
}
