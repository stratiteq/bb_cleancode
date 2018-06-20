using System;
using System.Collections.Generic;
using System.Text;
using UserRegistration.Helpers;
using UserRegistration.Models;

namespace UserRegistration.Services
{
    public class EmailService
    {
        public void SendEmail(Email email)
        {
            var handler = new EmailSender();
            handler.SendEmail(email.Message, email.Address);
        }
    }
}
