using System;

namespace UserRegistration.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Street)) throw new Exception();
            if (string.IsNullOrWhiteSpace(PostalCode)) throw new Exception();
            if (string.IsNullOrWhiteSpace(City)) throw new Exception();
        }
    }
}
