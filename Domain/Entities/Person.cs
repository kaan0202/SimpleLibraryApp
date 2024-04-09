using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person:BaseEntity
    {
        public string Name { get; set; }
        public int? BasketId { get; set; }
        public int? AddressId { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Address? Address { get; set; }
        public Basket? Basket { get; set; }
    }
}
