﻿using Application.DTOs.CatalogDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Add
{
    public class AddCatalogCommandRequest:IRequest<BaseResponse>
    {
        public CommandCatalogDto CatalogDto { get; set; }
    }
}
