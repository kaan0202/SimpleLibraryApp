using Application.DTOs.AuthorDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Single
{
    public class GetSingleAuthorQueryRequest:IRequest<BaseDataResponse<QueryAuthorDto>>
    {
        public int Id { get; set; }
    }
}
