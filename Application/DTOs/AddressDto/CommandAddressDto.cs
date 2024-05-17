using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AddressDto
{
    public class CommandAddressDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string AddressTitle { get; set; }
        public string Description { get; set; }
        public string OpenAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int NeighboorHoodId { get; set; }
    }
}
