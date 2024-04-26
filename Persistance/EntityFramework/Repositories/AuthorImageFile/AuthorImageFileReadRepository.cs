using Application.Repositories.AuthorImageFile;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.AuthorImageFile
{
    public class AuthorImageFileReadRepository : ReadRepository<Domain.Entities.File.AuthorImageFile>, IAuthorImageFileReadRepository
    {
        public AuthorImageFileReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
