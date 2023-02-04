using RepositoryPatternWithUnitOfWorkCore.IRepositories.InterFace;
using RepositoryPatternWithUnitOfWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWorkCore.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBooksRepository Books { get; }
        int Complete();
    }
}
