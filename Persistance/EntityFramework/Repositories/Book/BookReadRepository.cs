
using Application.Repositories.Book;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Book
{
    public class BookReadRepository : ReadRepository<Domain.Entities.Book>,IBookReadRepository
    {
        public BookReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
