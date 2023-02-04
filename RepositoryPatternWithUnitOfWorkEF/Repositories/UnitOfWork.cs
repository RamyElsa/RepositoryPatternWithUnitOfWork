
using RepositoryPatternWithUnitOfWorkCore.IRepositories;
using RepositoryPatternWithUnitOfWorkCore.IRepositories.InterFace;
using RepositoryPatternWithUnitOfWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWorkEF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Author> Authors { get; private set; }
        public IBooksRepository Boooks { get; private set; }

        public IBooksRepository Books => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(context);
            Boooks= new BooksRepository(context);
        }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
