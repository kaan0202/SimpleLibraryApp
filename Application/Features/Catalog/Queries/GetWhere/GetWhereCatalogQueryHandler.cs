using Application.Repositories.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetWhere
{
    public class GetWhereCatalogQueryHandler : IRequestHandler<GetWhereCatalogQueryRequest, GetWhereCatalogQueryResponse>
    {
        readonly ICatalogReadRepository _readRepository;

        public GetWhereCatalogQueryHandler(ICatalogReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        async Task<GetWhereCatalogQueryResponse> IRequestHandler<GetWhereCatalogQueryRequest, GetWhereCatalogQueryResponse>.Handle(GetWhereCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _readRepository.AnyAsync(data => data.Id == request.Id, false);
            if (result)
            {
                var catalog = _readRepository.GetWhere(data => data.Id == request.Id, false);
                return new()
                {
                    Catalog = catalog
                };
            }
            throw new Exception("Hata");
        }
    }
}
