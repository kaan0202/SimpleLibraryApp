using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Update
{
    public class UpdateBasketCommandRequest:IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public List<Domain.Entities.Book> Books { get; set; }
    }
}
