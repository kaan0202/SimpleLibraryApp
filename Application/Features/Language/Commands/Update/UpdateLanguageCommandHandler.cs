using Application.Repositories.Language;
using Application.UnitOfWork;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Update
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommandRequest, BaseResponse>
    {
        readonly ILanguageReadRepository _languageReadRepository;
        readonly ILanguageWriteRepository _languageWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public UpdateLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository, ILanguageReadRepository languageReadRepository, IUnitOfWork unitOfWork)
        {
            _languageReadRepository = languageReadRepository;
            _languageWriteRepository = languageWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _languageReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                Domain.Entities.Language language = new()
                {
                    CatalogId = request.CatalogId,
                    Name = request.Name,
                };
                _languageWriteRepository.Update(language);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Dil Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
