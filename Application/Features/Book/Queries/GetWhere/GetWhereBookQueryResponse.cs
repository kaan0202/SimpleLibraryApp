using Application.DTOs.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetWhere
{
    public class GetWhereBookQueryResponse
    {
        public IQueryable<Domain.Entities.Book> BookDto { get; set; }
    }
}
