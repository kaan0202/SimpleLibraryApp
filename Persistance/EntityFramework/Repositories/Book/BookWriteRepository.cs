using Application.Repositories.Book;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Book
{
    public class BookWriteRepository : WriteRepository<Domain.Entities.Book>,IBookWriteRepository
    {
        public BookWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
