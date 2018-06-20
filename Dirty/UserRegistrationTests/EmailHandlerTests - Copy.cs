using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration.Common;

namespace UserRegistrationTests
{
    [TestClass]
    public class EmailHandlerTests
    {
        private EmailHandler _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new EmailHandler();
        }

        [TestMethod]
        public void Given_emailbody_And_emailAddress_When_connection_is_setup_And_sending_email_Then_email_is_sent()
        {
            _sut.EmailServerConnectionSetup();
            _sut.SendEmail("Emailtest", "test@emailhandlertests.com");
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void Given_emailbody_And_emailAddress_When_connection_is_not_setup_And_sending_email_Then_email_throws_NullReferenceException()
        {
            _sut.SendEmail("Emailtest", "test@emailhandlertests.com");
        }
    }
}
