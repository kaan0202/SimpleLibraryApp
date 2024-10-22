using Application.DTOs.LanguageDto;
using Application.Repositories.Language;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetNameById
{
    public class Handler : IRequestHandler<Request, BaseDataResponse<List<QueryLanguageDto>>>
    {
        readonly private ILanguageReadRepository _languageReadRepository;

        public Handler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }

        public async Task<BaseDataResponse<List<QueryLanguageDto>>> Handle(Request request, CancellationToken cancellationToken)
        {
            var languages = _languageReadRepository.GetAll(false);
            List<QueryLanguageDto> results = new();
            foreach(var language in languages)
            {
                QueryLanguageDto languageDto = new();
                languageDto.Id = language.Id;
                languageDto.Name = language.Name;
                results.Add(languageDto);
            }
            return new SuccessDataResponse<List<QueryLanguageDto>>(results);
        }
    }
}
