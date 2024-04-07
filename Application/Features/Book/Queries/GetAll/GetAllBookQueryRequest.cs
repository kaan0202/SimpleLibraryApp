﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetAll
{
    public class GetAllBookQueryRequest:IRequest<GetAllBookQueryResponse>
    {
    }
}
