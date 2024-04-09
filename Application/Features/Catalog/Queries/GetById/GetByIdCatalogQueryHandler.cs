using Application.DTOs.CatalogDto;
using Application.Exceptions;
using Application.Repositories.Catalog;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetById
{
    public class GetByIdCatalogQueryHandler : IRequestHandler<GetByIdCatalogQueryRequest, BaseDataResponse<QueryCatalogDto>>
    {
        readonly ICatalogReadRepository _readRepository;

        public GetByIdCatalogQueryHandler(ICatalogReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<BaseDataResponse<QueryCatalogDto>> Handle(GetByIdCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _readRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var catalog = await _readRepository.GetByIdAsync(request.Id,false);
                QueryCatalogDto queryCatalogDto = new();
                queryCatalogDto.CatalogName = catalog.CatalogName;
                queryCatalogDto.Id = catalog.Id;
               return new SuccessDataResponse<QueryCatalogDto>(queryCatalogDto);
                

            }
            throw new NotFoundException("Hata");
        }
    }
}
