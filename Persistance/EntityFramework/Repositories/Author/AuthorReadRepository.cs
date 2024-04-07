using Application.Repositories.Author;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Author
{
    public class AuthorReadRepository : ReadRepository<Domain.Entities.Author>
    {
        public AuthorReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
