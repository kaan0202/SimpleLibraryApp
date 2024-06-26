﻿using Application.DTOs.BookDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetAll
{
    public class GetAllBookQueryRequest:IRequest<BaseDataResponse<List<QueryBookDto>>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
