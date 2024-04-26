using Application.Repositories.BookImageFile;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.BookImageFile
{
    public class BookImageFileWriteRepository : WriteRepository<Domain.Entities.File.BookImageFile>, IBookImageFileWriteRepository
    {
        public BookImageFileWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
