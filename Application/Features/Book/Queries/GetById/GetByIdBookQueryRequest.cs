using Application.DTOs.BookDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetById
{
    public class GetByIdBookQueryRequest : IRequest<BaseDataResponse<QueryBookDto>>
    {
        public int Id { get; set; }
    }
}
