using Application.UnitOfWork;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly LibraryDbContext _libraryDbContext;
        public UnitOfWork( LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task<int> SaveChangesAsync()
        {
           return await _libraryDbContext.SaveChangesAsync();
        }
    }
}
