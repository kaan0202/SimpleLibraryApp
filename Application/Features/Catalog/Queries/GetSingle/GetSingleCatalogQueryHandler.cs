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

namespace Application.Features.Catalog.Queries.GetSingle
{
    public class GetSingleCatalogQueryHandler : IRequestHandler<GetSingleCatalogQueryRequest, BaseDataResponse<QueryCatalogDto>>
    {
        readonly ICatalogReadRepository _readRepository;

        public GetSingleCatalogQueryHandler(ICatalogReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

       public async Task<BaseDataResponse<QueryCatalogDto>> Handle(GetSingleCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _readRepository.AnyAsync(data => data.Id == request.Id,false);
            if(result)
            {
                var catalog = await _readRepository.GetSingleAsync(data => data.Id == request.Id,false);    
                QueryCatalogDto catalogDto = new();
                catalogDto.CatalogName=catalog.CatalogName;
                catalogDto.Id=request.Id;

                return new SuccessDataResponse<QueryCatalogDto>(catalogDto);
               
            }
            throw new NotFoundException("Hata");
        }
    }
}
