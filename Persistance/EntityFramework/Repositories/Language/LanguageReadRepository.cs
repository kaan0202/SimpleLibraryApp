using Application.Repositories.Language;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Language
{
    public class LanguageReadRepository : ReadRepository<Domain.Entities.Language>,ILanguageReadRepository
    {
        public LanguageReadRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
