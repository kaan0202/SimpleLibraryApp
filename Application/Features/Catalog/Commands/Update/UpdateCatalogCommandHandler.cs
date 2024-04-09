﻿using Application.Repositories.Catalog;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Update
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommandRequest, BaseResponse>
    {
        readonly ICatalogReadRepository _catalogReadRepository;
        readonly ICatalogWriteRepository _catalogWriteRepository;
        public UpdateCatalogCommandHandler( ICatalogReadRepository catalogReadRepository,ICatalogWriteRepository catalogWriteRepository)
        {
            _catalogReadRepository = catalogReadRepository;
            _catalogWriteRepository = catalogWriteRepository;
        }
        public async Task<BaseResponse> Handle(UpdateCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _catalogReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if(result == true)
            {
                Domain.Entities.Catalog catalog = new()
                {
                    CatalogName = request.CatalogName,
                    LanguageId = request.LanguageId,

                };
                _catalogWriteRepository.Update(catalog);
                return new SuccessWithNoDataResponse("Katalog Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
