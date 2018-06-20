using System;

namespace UserRegistration.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Email Email { get; } = new Email();
        public Address Address { get; } = new Address();

        public virtual void Validate()
        {
            Address.Validate();
            Email.Validate();
            if (string.IsNullOrWhiteSpace(PhoneNumber)) throw new Exception();
            if (string.IsNullOrWhiteSpace(FirstName)) throw new Exception();
            if (string.IsNullOrWhiteSpace(LastName)) throw new Exception();
        }
    }
}
