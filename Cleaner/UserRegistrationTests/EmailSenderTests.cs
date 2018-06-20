using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration.Helpers;

namespace UserRegistrationTests
{
    [TestClass]
    public class EmailSenderTests
    {
        private EmailSender _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new EmailSender();
        }

        [TestMethod]
        public void Given_emailbody_And_emailAddress_When_connection_is_setup_And_sending_email_Then_email_is_sent()
        {
            _sut.SendEmail("Emailtest", "test@emailhandlertests.com");
        }
    }
}
