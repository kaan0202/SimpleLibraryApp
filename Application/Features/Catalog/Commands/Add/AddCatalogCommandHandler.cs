using Application.Repositories.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Add
{
    public class AddCatalogCommandHandler : IRequestHandler<AddCatalogCommandRequest, AddCatalogCommandResponse>
    {
        readonly ICatalogWriteRepository _catalogWriteRepository;
        public AddCatalogCommandHandler(ICatalogWriteRepository catalogWriteRepository)
        {
            _catalogWriteRepository = catalogWriteRepository;
        }
        async Task<AddCatalogCommandResponse> IRequestHandler<AddCatalogCommandRequest, AddCatalogCommandResponse>.Handle(AddCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            await _catalogWriteRepository.AddAsync(request.Catalog);
            return new();
        }
    }
}
