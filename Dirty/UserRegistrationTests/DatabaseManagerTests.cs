using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration.Common;
using UserRegistration.Models;

namespace UserRegistrationTests
{
    [TestClass]
    public class DatabaseManagerTests
    {
        private DatabaseManager _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new DatabaseManager();
        }

        [TestMethod]
        public void Given_user_When_save_user_Then_return_user_id()
        {
            // arrange
            var user = new User()
            {
                FirstName = "John",
                LastName = "Doe",
                StreetAddress = "Smallstreet 1",
                PostalCode = "111 11",
                City = "Smallville",
                PhoneNumber = "123456",
                EmailAddress = "john.doe@somemail.com",
                UserType = UserType.Participant
            };

            // act
            user.Id = _sut.Save(user);

            // assert
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void Given_user_When_update_user_Then_return_user_id()
        {
            // arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                StreetAddress = "Smallstreet 1",
                PostalCode = "111 11",
                City = "Smallville",
                PhoneNumber = "123456",
                EmailAddress = "john.doe@somemail.com",
                UserType = UserType.Participant
            };

            // act
            var actual = _sut.Update(user);

            // assert
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void Given_user_When_delete_user_Then_return_0()
        {
            // arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                StreetAddress = "Smallstreet 1",
                PostalCode = "111 11",
                City = "Smallville",
                PhoneNumber = "123456",
                EmailAddress = "john.doe@somemail.com",
                UserType = UserType.Participant
            };

            // act
            var actual = _sut.Delete(user);

            // assert
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void Given_userId_1_When_get_user_Then_return_user()
        {
            // arrange
            var userId = 1;

            // act
            var actual = _sut.GetUser(1);

            // assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.FirstName);
            Assert.IsNotNull(actual.LastName);
            Assert.IsNotNull(actual.EmailAddress);
            Assert.IsNotNull(actual.PhoneNumber);
            Assert.IsNotNull(actual.StreetAddress);
            Assert.IsNotNull(actual.PostalCode);
            Assert.IsNotNull(actual.City);
        }
    }
}
