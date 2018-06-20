using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistration.Models
{
    public class Email
    {
        public string Address { get; set; }
        public string Message { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Address)) throw new Exception();
        }
    }
}
