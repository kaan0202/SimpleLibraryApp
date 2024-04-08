using Application.Repositories.Language;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Add
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommandRequest, BaseResponse>
    {
        readonly ILanguageWriteRepository _languageWriteRepository;
        public AddLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository)
        {
            _languageWriteRepository = languageWriteRepository;
        }
        public async Task<BaseResponse> Handle(AddLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            await _languageWriteRepository.AddAsync(request.Language);
            return new SuccessWithNoDataResponse("Dil eklendi");
        }
    }
}
