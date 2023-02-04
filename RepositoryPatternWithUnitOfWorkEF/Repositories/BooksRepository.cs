using RepositoryPatternWithUnitOfWorkCore.IRepositories.InterFace;
using RepositoryPatternWithUnitOfWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWorkEF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbContext _context;
        public BooksRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
