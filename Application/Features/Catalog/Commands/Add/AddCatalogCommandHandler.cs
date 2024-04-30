using Application.Repositories.Catalog;
using Application.UnitOfWork;
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
        readonly IUnitOfWork _unitOfWork;
        public AddCatalogCommandHandler(ICatalogWriteRepository catalogWriteRepository, IUnitOfWork unitOfWork)
        {
            _catalogWriteRepository = catalogWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(AddCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            await _catalogWriteRepository.AddAsync(request.Catalog);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Katalog Eklendi");
        }
    }
}
