using Application.DTOs.BookDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Update
{
    public class UpdateBookCommandRequest:IRequest<BaseResponse>
    {
        public CommandBookDto  BookDto { get; set; }
    }
}
