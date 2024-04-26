using Application.Repositories;
using Application.Repositories.BookImageFile;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.BookImageFile
{
    public class BookImageFileReadRepository : ReadRepository<Domain.Entities.File.BookImageFile>, IBookImageFileReadRepository
    {
        public BookImageFileReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
