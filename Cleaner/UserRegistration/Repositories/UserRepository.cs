using System;
using UserRegistration.Interfaces;
using UserRegistration.Models;
using UserRegistration.Services;

namespace UserRegistration.Repositories
{

    public class UserRepository : IUserRepository
    {
        private int id = 1;

        public void Save(User user)
        {
            user.Id++;
            Console.WriteLine($"Saved user with id: {user.Id}");
        }

        public void Delete(User user)
        {
            Console.WriteLine($"Deleted user with id: {user.Id}");
        }

        public User GetById(int userId)
        {
            Console.WriteLine($"Fetching user with id: {userId}");

            // used only for mocking purposes in brownbag
            var participant = new Participant()
            {
                Id = id++,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456"
            };
            participant.Email.Address = "john.doe@somemail.com";
            participant.Address.Street = "Smallstreet 1";
            participant.Address.PostalCode = "111 11";
            participant.Address.City = "Smallville";

            return participant;
        }
    }
}
