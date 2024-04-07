using Application.Repositories.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Update
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommandRequest, UpdateCatalogCommandResponse>
    {
        readonly ICatalogReadRepository _catalogReadRepository;
        readonly ICatalogWriteRepository _catalogWriteRepository;
        public UpdateCatalogCommandHandler( ICatalogReadRepository catalogReadRepository,ICatalogWriteRepository catalogWriteRepository)
        {
            _catalogReadRepository = catalogReadRepository;
            _catalogWriteRepository = catalogWriteRepository;
        }
        async Task<UpdateCatalogCommandResponse> IRequestHandler<UpdateCatalogCommandRequest, UpdateCatalogCommandResponse>.Handle(UpdateCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _catalogReadRepository.AnyAsync(data => data.Id == request.Catalog.Id,false);
            if(result = true)
            {
                _catalogWriteRepository.Update(request.Catalog);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
