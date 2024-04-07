using Application.DTOs.AuthorDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Where
{
    public class GetWhereAuthorQueryRequest:IRequest<GetWhereAuthorQueryResponse>
    {
        public int Id { get; set; }
    }
}
