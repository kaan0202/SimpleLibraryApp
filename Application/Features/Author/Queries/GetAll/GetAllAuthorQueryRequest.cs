using Application.DTOs.AuthorDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.GetAll
{
    public class GetAllAuthorQueryRequest:IRequest<BaseDataResponse<List<QueryAuthorDto>>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
