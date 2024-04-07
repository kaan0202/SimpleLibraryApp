using Application.DTOs.CatalogDto;
using Application.Repositories.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetSingle
{
    public class GetSingleCatalogQueryHandler : IRequestHandler<GetSingleCatalogQueryRequest, GetSingleCatalogQueryResponse>
    {
        readonly ICatalogReadRepository _readRepository;

        public GetSingleCatalogQueryHandler(ICatalogReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        async Task<GetSingleCatalogQueryResponse> IRequestHandler<GetSingleCatalogQueryRequest, GetSingleCatalogQueryResponse>.Handle(GetSingleCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _readRepository.AnyAsync(data => data.Id == request.Id,false);
            if(result)
            {
                var catalog = await _readRepository.GetSingleAsync(data => data.Id == request.Id,false);    
                QueryCatalogDto catalogDto = new();
                catalogDto.CatalogName=catalog.CatalogName;
                catalogDto.Id=request.Id;

                return new()
                {
                    
                    CatalogDto= catalogDto,
                };
            }
            throw new Exception("Hata");
        }
    }
}
