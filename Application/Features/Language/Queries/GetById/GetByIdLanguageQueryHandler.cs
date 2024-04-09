using Application.DTOs.LanguageDto;
using Application.Exceptions;
using Application.Repositories.Language;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetById
{
    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQueryRequest, BaseDataResponse<QueryLanguageDto>>
    {
        readonly ILanguageReadRepository _languageReadRepository;

        public GetByIdLanguageQueryHandler(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;
        }

        public async Task<BaseDataResponse<QueryLanguageDto>> Handle(GetByIdLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _languageReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result) 
            { 
                var language = await _languageReadRepository.GetByIdAsync(request.Id);
                QueryLanguageDto languageDto = new();
                languageDto.Id = request.Id;
                languageDto.Name=language.Name;

                return new SuccessDataResponse<QueryLanguageDto>(languageDto);
               
            }
            throw new NotFoundException("Hata");
        }
    }
}
