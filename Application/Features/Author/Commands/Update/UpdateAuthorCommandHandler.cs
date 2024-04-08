using Application.Repositories.Author;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Update
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, BaseResponse>
    { 
        readonly IAuthorWriteRepository _authorWriteRepository;
        readonly IAuthorReadRepository _authorReadRepository;

        public UpdateAuthorCommandHandler(IAuthorReadRepository authorReadRepository,IAuthorWriteRepository authorWriteRepository)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }

         public async Task<BaseResponse> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.Author.Id,false);
            if (result==true)
            {
                 _authorWriteRepository.Update(request.Author);
                return new SuccessWithNoDataResponse("Yazar Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
