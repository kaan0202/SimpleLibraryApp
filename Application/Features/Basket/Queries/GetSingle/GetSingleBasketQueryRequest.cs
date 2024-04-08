using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetSingle
{
    public class GetSingleBasketQueryRequest:IRequest<BaseDataResponse<Domain.Entities.Basket>>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
    }
}
