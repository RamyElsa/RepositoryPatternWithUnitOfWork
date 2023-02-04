using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWorkCore.IRepositories;
using RepositoryPatternWithUnitOfWorkCore.IRepositories.InterFace;
using RepositoryPatternWithUnitOfWorkCore.Models;
using RepositoryPatternWithUnitOfWorkEF;

namespace RepositoryPatternWithUnitOfWorkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public AuthorController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Authors.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task <IActionResult> GetByIdAsync()
        {
            return Ok( await _unitOfWork.Authors.GetByIdAsync(2));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_unitOfWork.Authors.GetAll());
        }
    }
}
