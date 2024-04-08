using Application.Repositories.Catalog;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Add
{
    public class AddCatalogCommandHandler : IRequestHandler<AddCatalogCommandRequest, BaseResponse>
    {
        readonly ICatalogWriteRepository _catalogWriteRepository;
        public AddCatalogCommandHandler(ICatalogWriteRepository catalogWriteRepository)
        {
            _catalogWriteRepository = catalogWriteRepository;
        }
       public async Task<BaseResponse> Handle(AddCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            await _catalogWriteRepository.AddAsync(request.Catalog);
            return new SuccessWithNoDataResponse("Katalog Eklendi");
        }
    }
}
