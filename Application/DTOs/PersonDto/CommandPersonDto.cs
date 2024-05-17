using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.PersonDto
{
    public class CommandPersonDto
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
