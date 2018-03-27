using System;

namespace Api.Authentication.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
