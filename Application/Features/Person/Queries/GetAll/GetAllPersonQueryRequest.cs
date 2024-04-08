﻿using Application.DTOs.PersonDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetAll
{
    public class GetAllPersonQueryRequest:IRequest<BaseDataResponse<List<QueryPersonDto>>>
    {
    }
}
