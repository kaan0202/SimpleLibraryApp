using Application.Repositories.Author;
using Application.Repositories.AuthorImageFile;
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

        public RemoveAuthorImageFileCommandHandler(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }

        public async Task<BaseResponse> Handle(RemoveAuthorImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await  _authorReadRepository.Table.Include(x =>x.Images).FirstOrDefaultAsync(x =>x.Id == request.Id);
            Domain.Entities.File.AuthorImageFile authorImageFile =  author.Images.FirstOrDefault(x => x.Id == request.ImageId);   
            if (author != null)
            {
                author.Images.Remove(authorImageFile);

                return new SuccessWithNoDataResponse("Resim silindi");
            }
            throw new Exception("Hata");
        }
    }
}
