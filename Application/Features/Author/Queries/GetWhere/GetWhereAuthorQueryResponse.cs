using Application.DTOs.AuthorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Where
{
    public class GetWhereAuthorQueryResponse
    {
        public IQueryable<Domain.Entities.Author> AuthorDto { get; set; }
    }
}
