using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Language
{
    public class LanguageWriteRepository : WriteRepository<Domain.Entities.Language>
    {
        public LanguageWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
