using Application.DTOs.NeighboorHoodDto;
using Application.DTOs.PersonDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AddressDto
{
    public class QueryAddressDto
    {
        public int Id { get; set; }
        public QueryPersonDto Person { get; set; }
        public string AddressTitle { get; set; }
        public string Description { get; set; }
        public string OpenAddress { get; set; }
        public string PhoneNumber { get; set; }
        public QueryNeighboorHoodDto NeighboorHood { get; set; }
    }
}
