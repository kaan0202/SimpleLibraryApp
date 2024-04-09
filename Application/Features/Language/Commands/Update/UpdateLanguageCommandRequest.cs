﻿using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Update
{
    public class UpdateLanguageCommandRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CatalogId { get; set; }
    }
}
