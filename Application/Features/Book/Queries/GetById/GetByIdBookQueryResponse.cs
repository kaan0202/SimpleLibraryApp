using Application.DTOs.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetById
{
    public class GetByIdBookQueryResponse
    {
        public QueryBookDto BookDto { get; set; }
    }
}
