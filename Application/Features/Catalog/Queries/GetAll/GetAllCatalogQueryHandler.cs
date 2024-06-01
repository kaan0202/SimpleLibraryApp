using Application.DTOs.CatalogDto;
using Application.Repositories.Catalog;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetAll
{
    public class GetAllCatalogQueryHandler : IRequestHandler<GetAllCatalogQueryRequest, BaseDataResponse<List<QueryCatalogDto>>>
    {
        readonly ICatalogReadRepository _readRepository;
        public GetAllCatalogQueryHandler(ICatalogReadRepository catalogReadRepository)
        {
            _readRepository = catalogReadRepository;
        }
        public async Task<BaseDataResponse<List<QueryCatalogDto>>> Handle(GetAllCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _readRepository.GetAll(false).Count();
            var catalogs = await  _readRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
            List<QueryCatalogDto> queryCatalogDtos = new();
            foreach (var catalog in catalogs)
            {
                QueryCatalogDto queryCatalogDto = new();
                queryCatalogDto.CatalogName = catalog.CatalogName;
                queryCatalogDto.Id = catalog.Id;
                queryCatalogDtos.Add(queryCatalogDto);
            }
            return new SuccessDataResponse<List<QueryCatalogDto>>(queryCatalogDtos,totalCount);
            
        }
    }
}
