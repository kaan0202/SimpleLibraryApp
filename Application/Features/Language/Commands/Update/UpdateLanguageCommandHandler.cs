using Application.Repositories.Language;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Update
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommandRequest, UpdateLanguageCommandResponse>
    {
        readonly ILanguageReadRepository _languageReadRepository;
        readonly ILanguageWriteRepository _languageWriteRepository;
        public UpdateLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository, ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
            _languageWriteRepository = languageWriteRepository;
        }
        async Task<UpdateLanguageCommandResponse> IRequestHandler<UpdateLanguageCommandRequest, UpdateLanguageCommandResponse>.Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _languageReadRepository.AnyAsync(data => data.Id == request.Language.Id,false);
            if (result)
            {
                _languageWriteRepository.Update(request.Language);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
