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

namespace Application.Features.Language.Commands.Add
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommandRequest, BaseResponse>
    {
        readonly ILanguageWriteRepository _languageWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public AddLanguageCommandHandler(ILanguageWriteRepository languageWriteRepository, IUnitOfWork unitOfWork)
        {
            _languageWriteRepository = languageWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(AddLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            await _languageWriteRepository.AddAsync(request.Language);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Dil eklendi");
        }
    }
}
