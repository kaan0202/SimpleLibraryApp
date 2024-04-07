using Application.DTOs.CatalogDto;
using Application.Repositories.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetAll
{
    public class GetAllCatalogQueryHandler : IRequestHandler<GetAllCatalogQueryRequest, GetAllCatalogQueryResponse>
    {
        readonly ICatalogReadRepository _readRepository;
        public GetAllCatalogQueryHandler(ICatalogReadRepository catalogReadRepository)
        {
            _readRepository = catalogReadRepository;
        }
        async Task<GetAllCatalogQueryResponse> IRequestHandler<GetAllCatalogQueryRequest, GetAllCatalogQueryResponse>.Handle(GetAllCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            var catalogs = await  _readRepository.GetAll(false).ToListAsync();
            List<QueryCatalogDto> queryCatalogDtos = new();
            foreach (var catalog in catalogs)
            {
                QueryCatalogDto queryCatalogDto = new();
                queryCatalogDto.CatalogName = catalog.CatalogName;
                queryCatalogDto.Id = catalog.Id;
                queryCatalogDtos.Add(queryCatalogDto);
            }
            return new()
            {
                CatalogDtos = queryCatalogDtos
            };
        }
    }
}
