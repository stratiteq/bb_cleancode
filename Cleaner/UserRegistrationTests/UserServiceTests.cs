using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration.Models;
using UserRegistration.Repositories;
using UserRegistration.Services;

namespace UserRegistrationTests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _sut;

        [TestInitialize]
        public void Initialize()
        {
            var userRepository = new UserRepository();
            _sut = new UserService(userRepository);
        }

        [TestMethod]
        public void Given_1_When_fetching_me_a_user_Then_return_user()
        {
            // arrange
            var userId = 1;

            // act
            var actual = _sut.GetById(1);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(userId, actual.Id);
        }

        [TestMethod]
        public void Given_UserRegistrationAction_create_When_user_is_valid_Then_return_Id()
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
            _sut.Save(user);

            // assert
            Assert.IsTrue(user.Id > 0);
        }

        [TestMethod]
        public void Given_UserRegistrationAction_update_When_user_is_valid_Then_return_Id()
        {
            // arrange
            var expected = 1;

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
            _sut.Save(user);

            // assert
            Assert.AreEqual(expected, user.Id);
        }

        //[TestMethod]
        //public void Given_UserRegistrationAction_delete_When_user_is_valid_Then_return_0()
        //{
        //    // arrange
        //    var expected = 0;

        //    var user = new User()
        //    {
        //        Id = 1,
        //        FirstName = "John",
        //        LastName = "Doe",
        //        StreetAddress = "Smallstreet 1",
        //        PostalCode = "111 11",
        //        City = "Smallville",
        //        PhoneNumber = "123456",
        //        EmailAddress = "john.doe@somemail.com",
        //        UserType = UserType.Speeker
        //    };

        //    // act
        //    var actual = _sut.CreateUpdateOrDeleteUser(UserRegistrationAction.Delete, user);

        //    // assert
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Given_invalid_user_name_When_validating_user_Then_return_negative_1()
        //{
        //    // arrange
        //    var expected = -1;

        //    var user = new User()
        //    {
        //        FirstName = "J",
        //        LastName = "D",
        //        StreetAddress = "Smallstreet 1",
        //        PostalCode = "111 11",
        //        City = "Smallville",
        //        PhoneNumber = "123456",
        //        EmailAddress = "john.doe@somemail.com",
        //        UserType = UserType.Participant
        //    };

        //    // act
        //    var actual = _sut.CreateUpdateOrDeleteUser(UserRegistrationAction.Create, user);

        //    // assert
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Given_invalid_user_phoneNumber_When_validating_user_Then_return_negative_1()
        //{
        //    // arrange
        //    var expected = -1;

        //    var user = new User()
        //    {
        //        FirstName = "John",
        //        LastName = "Doe",
        //        StreetAddress = "Smallstreet 1",
        //        PostalCode = "111 11",
        //        City = "Smallville",
        //        PhoneNumber = "",
        //        EmailAddress = "john.doe@somemail.com",
        //        UserType = UserType.Participant
        //    };

        //    // act
        //    var actual = _sut.CreateUpdateOrDeleteUser(UserRegistrationAction.Create, user);

        //    // assert
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Given_invalid_user_emailaddress_When_validating_user_Then_return_negative_1()
        //{
        //    // arrange
        //    var expected = -1;

        //    var user = new User()
        //    {
        //        FirstName = "John",
        //        LastName = "Doe",
        //        StreetAddress = "Smallstreet 1",
        //        PostalCode = "111 11",
        //        City = "Smallville",
        //        PhoneNumber = "123456",
        //        EmailAddress = "",
        //        UserType = UserType.Participant
        //    };

        //    // act
        //    var actual = _sut.CreateUpdateOrDeleteUser(UserRegistrationAction.Create, user);

        //    // assert
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
