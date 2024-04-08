using Application.DTOs.LanguageDto;
using Application.Repositories.Language;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetAll
{
    public class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQueryRequest, BaseDataResponse<List<QueryLanguageDto>>>
    {
        readonly ILanguageReadRepository _languageReadRepository;

        public GetAllLanguageQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }

        public async Task<BaseDataResponse<List<QueryLanguageDto>>> Handle(GetAllLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            var languages = await _languageReadRepository.GetAll().ToListAsync();
            List<QueryLanguageDto> queryLanguageDtos = new();
            foreach (var language in languages)
            {
                QueryLanguageDto queryLanguageDto = new();
                queryLanguageDto.Name = language.Name;
                queryLanguageDto.Id = language.Id;
                queryLanguageDtos.Add(queryLanguageDto);
            }
            return new SuccessDataResponse<List<QueryLanguageDto>>(queryLanguageDtos);
            
        }
        
    }
}
