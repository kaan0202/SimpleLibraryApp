using Application.Repositories.Author;
using Application.UnitOfWork;
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
        readonly IUnitOfWork _unitOfWork;

        public AddAuthorCommandHandler(IAuthorWriteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(AddAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Author authorData = new()
            {
                Name = request.Author.Name,
                Surname = request.Author.Surname,
                BirthDay = request.Author.BirthDay,
                
            };
           var author = await _repository.AddAsync(authorData);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Yazar Eklendi");
        }
    }
}
