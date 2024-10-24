﻿using Application.DTOs.LanguageDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Delete
{
    public class Request:IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
