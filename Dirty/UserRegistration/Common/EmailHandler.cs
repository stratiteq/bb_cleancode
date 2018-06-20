using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistration.Common
{
    public class EmailHandler
    {
        private bool isConnected = false; // only used for demo purpose in BrownBag to simulate connection to email server

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmailHandler()
        {
        }

        public void EmailServerConnectionSetup()
        {
            Console.WriteLine("Logic for connecting to email server should go here");
            isConnected = true;
        }

        public void SendEmail(string strBodyOfEmail, string emAddr)
        {
            Console.WriteLine("Logic for sending email to participant should go here");
            if (!isConnected)
            {
                throw new NullReferenceException("The email server connection was not setup");
            }
        }
    }
}
