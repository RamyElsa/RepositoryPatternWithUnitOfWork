using RepositoryPatternWithUnitOfWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWorkCore.IRepositories.InterFace
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetBooks();
    }
}
