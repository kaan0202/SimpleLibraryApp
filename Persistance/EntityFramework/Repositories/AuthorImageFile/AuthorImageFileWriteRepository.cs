using Application.Repositories.AuthorImageFile;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.AuthorImageFile
{
    public class AuthorImageFileWriteRepository : WriteRepository<Domain.Entities.File.AuthorImageFile>, IAuthorImageFileWriteRepository
    {
        public AuthorImageFileWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
