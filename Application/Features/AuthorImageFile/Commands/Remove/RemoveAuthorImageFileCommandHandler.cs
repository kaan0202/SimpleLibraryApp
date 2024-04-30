using Application.Repositories.Author;
using Application.Repositories.AuthorImageFile;
using Application.UnitOfWork;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthorImageFile.Commands.Remove
{
    public class RemoveAuthorImageFileCommandHandler : IRequestHandler<RemoveAuthorImageFileCommandRequest, BaseResponse>
    {
        readonly IAuthorReadRepository _authorReadRepository;
        readonly IAuthorWriteRepository _authorWriteRepository;
        readonly IUnitOfWork _unitOfWork;

        public RemoveAuthorImageFileCommandHandler(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository, IUnitOfWork unitOfWork = null)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(RemoveAuthorImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await  _authorReadRepository.Table.Include(x =>x.Images).FirstOrDefaultAsync(x =>x.Id == request.Id);
            Domain.Entities.File.AuthorImageFile authorImageFile =  author.Images.FirstOrDefault(x => x.Id == request.ImageId);   
            if (author != null)
            {
                author.Images.Remove(authorImageFile);
                await _unitOfWork.SaveChangesAsync();

                return new SuccessWithNoDataResponse("Resim silindi");
            }
            throw new Exception("Hata");
        }
    }
}
