using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistration.Models
{
    public class Participant : User
    {
        public Participant()
        {
            Email.Message =
                $"Dear {FirstName} {LastName} \n" +
                "You are welcome to the super event you have registered for and we look forward to have you as a guest \n" +
                "Please verify you attendance by clicking the email link below \n\n" +
                $"www.somesortofbrownbagevent.com/guest/{Id} \n\n" +
                "Best regards \n" +
                "Admin";
        }
    }
}
