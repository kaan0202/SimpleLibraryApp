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

namespace Application.Features.Author.Commands.Update
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, BaseResponse>
    { 
        readonly IAuthorWriteRepository _authorWriteRepository;
        readonly IAuthorReadRepository _authorReadRepository;
        readonly IUnitOfWork _unitOfWork;
        public UpdateAuthorCommandHandler(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository, IUnitOfWork unitOfWork)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.AuthorDto.Id,false);
            if (result==true)
            {
                Domain.Entities.Author author = new()
                {
                    BirthDay = request.AuthorDto.BirthDay,
                    Name = request.AuthorDto.Name,
                    Surname = request.AuthorDto.Surname,

                };
                 _authorWriteRepository.Update(author);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Yazar Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
