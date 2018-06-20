using System;

namespace UserRegistration.Helpers
{
    public class EmailSender
    {
        public EmailSender()
        {
            EmailServerConnectionSetup();
        }

        private void EmailServerConnectionSetup() => Console.WriteLine("Logic for connecting to email server should go here");

        public void SendEmail(string strBodyOfEmail, string emAddr) => Console.WriteLine("Logic for sending email to participant should go here");
    }
}
