using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Update
{
    public class UpdatePersonCommandRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? AddressId { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
