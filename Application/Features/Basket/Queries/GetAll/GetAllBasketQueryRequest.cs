using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetAll
{
    public class GetAllBasketQueryRequest:IRequest<BaseDataResponse<List<Domain.Entities.Basket>>>
    {
        public int PersonId { get; set; }
    }
}
