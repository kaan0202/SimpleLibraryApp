using Application.Repositories.Language;
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
        public UpdateLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository, ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
            _languageWriteRepository = languageWriteRepository;
        }
        public async Task<BaseResponse> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _languageReadRepository.AnyAsync(data => data.Id == request.Language.Id,false);
            if (result)
            {
                _languageWriteRepository.Update(request.Language);
                return new SuccessWithNoDataResponse("Dil Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
