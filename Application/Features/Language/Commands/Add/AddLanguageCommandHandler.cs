using Application.Repositories.Language;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Add
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommandRequest, AddLanguageCommandResponse>
    {
        readonly ILanguageWriteRepository _languageWriteRepository;
        public AddLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository)
        {
            _languageWriteRepository = languageWriteRepository;
        }
        async Task<AddLanguageCommandResponse> IRequestHandler<AddLanguageCommandRequest, AddLanguageCommandResponse>.Handle(AddLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            await _languageWriteRepository.AddAsync(request.Language);
            return new();
        }
    }
}
