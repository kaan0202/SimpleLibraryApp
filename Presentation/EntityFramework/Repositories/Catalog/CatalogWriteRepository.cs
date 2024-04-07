using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories.Catalog
{
    public class CatalogWriteRepository : WriteRepository<Domain.Entities.Catalog>
    {
        public CatalogWriteRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
