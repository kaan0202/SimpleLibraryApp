using Application.Repositories.Author;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Add
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommandRequest, BaseResponse>
    {
        readonly IAuthorWriteRepository _repository;

        public AddAuthorCommandHandler(IAuthorWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(AddAuthorCommandRequest request, CancellationToken cancellationToken)
        {
           var author = await _repository.AddAsync(request.Author);
            return new SuccessWithNoDataResponse("Yazar Eklendi");
        }
    }
}
