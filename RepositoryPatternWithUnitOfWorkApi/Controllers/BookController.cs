using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWorkCore.Consts;
using RepositoryPatternWithUnitOfWorkCore.IRepositories;
using RepositoryPatternWithUnitOfWorkCore.IRepositories.InterFace;
using RepositoryPatternWithUnitOfWorkCore.Models;

namespace RepositoryPatternWithUnitOfWorkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Books.GetByIdAsync(2));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }


        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "Php", new[] {"Author"}));
        }

        [HttpGet("GetAllWithAuthors")]
        public async Task<IActionResult> GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title == "Php", new[] { "Author" }));
        }

        [HttpGet("GetOrderBy")]
        public async Task<IActionResult> GetOrderBy()
        {
            return Ok(_unitOfWork.Books.FindAllAsync(b => b.Title == "Php",null,null,b=>b.Id,OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public  IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Html", AuthorId = 1 });
           _unitOfWork.Complete();
            return Ok(book);
            // return Ok(_unitOfWork.Books.Add(new Book { Title = "Html",AuthorId=1}));
            // return Ok(_unitOfWork.Books.GetBooks());
        }
    }
}
