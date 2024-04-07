using Application.DTOs.AuthorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Single
{
    public class GetSingleAuthorQueryResponse
    {
        public QueryAuthorDto  AuthorDto { get; set; }
    }
}
