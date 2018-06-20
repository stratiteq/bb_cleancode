using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration.Models;
using UserRegistration.Repositories;

namespace UserRegistrationTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository _userRepository;

        [TestInitialize]
        public void Initialize()
        {
            _userRepository = new UserRepository();
        }

        [TestMethod]
        public void Given_user_When_save_user_Then_return_user_id()
        {
            // arrange
            var user = new Speaker()
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456"
            };
            user.Address.Street = "Smallstreet 1";
            user.Address.PostalCode = "111 11";
            user.Address.City = "Smallville";
            user.Email.Address = "john.doe@somemail.com";

            // act
            _userRepository.Save(user);

            // assert
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void Given_user_When_update_user_Then_return_user_id()
        {
            // arrange
            var user = new Speaker()
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456"
            };
            user.Address.Street = "Smallstreet 1";
            user.Address.PostalCode = "111 11";
            user.Address.City = "Smallville";
            user.Email.Address = "john.doe@somemail.com";

            // act
            _userRepository.Save(user);

            // assert
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void Given_user_When_delete_user_Then_return_0()
        {
            // arrange
            var user = new Participant()
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456"
            };
            user.Address.Street = "Smallstreet 1";
            user.Address.PostalCode = "111 11";
            user.Address.City = "Smallville";
            user.Email.Address = "john.doe@somemail.com";

            // act
            _userRepository.Delete(user);

            // assert
        }

        [TestMethod]
        public void Given_userId_1_When_get_user_Then_return_user()
        {
            // arrange

            // act
            var actual = _userRepository.GetById(1);

            // assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.FirstName);
            Assert.IsNotNull(actual.LastName);
            Assert.IsNotNull(actual.Email.Address);
            Assert.IsNotNull(actual.PhoneNumber);
            Assert.IsNotNull(actual.Address.Street);
            Assert.IsNotNull(actual.Address.PostalCode);
            Assert.IsNotNull(actual.Address.City);
        }
    }
}
