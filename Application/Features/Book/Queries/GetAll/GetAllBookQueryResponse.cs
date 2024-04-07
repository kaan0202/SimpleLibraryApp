using Application.DTOs.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetAll
{
    public class GetAllBookQueryResponse
    {
        public List<QueryBookDto> BookDtos { get; set; }
    }
}
