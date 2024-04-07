using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Book
{
    public interface IBookWriteRepository:IWriteRepository<Domain.Entities.Book>
    {
    }
}
