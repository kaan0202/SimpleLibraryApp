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

namespace Application.Features.Language.Commands.Delete
{
    public class Handler : IRequestHandler<Request,BaseResponse>
    {
        readonly ILanguageWriteRepository _languageWriteRepository;
        readonly IUnitOfWork _unitOfWork;
       

        public Handler(ILanguageWriteRepository languageWriteRepository, IUnitOfWork unitOfWork)
        {
            _languageWriteRepository = languageWriteRepository;
            _unitOfWork = unitOfWork;
        }

       

      
        public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
        {
           await _languageWriteRepository.RemoveByIdAsync(request.Id);
           await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Başarılı");
        }
    }
}
