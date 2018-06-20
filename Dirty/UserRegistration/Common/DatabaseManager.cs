using System;
using UserRegistration.Models;

namespace UserRegistration.Common
{
    internal interface IDatabaseManager
    {
        int Save(User user);
        int Update(User user);
        int Delete(User user);
        User GetUser(int userId);
    }

    public class DatabaseManager : IDatabaseManager
    {
        private static int id = 1;

        /// <summary>
        /// Saves a user to the database
        /// </summary>
        //public int Save(User user)
        //{
        //    //save user to database
        //    Console.WriteLine($"Saved user {user.FirstName} {user.LastName}");
        //    //return the new identifier
        //    return new Random().Next(1, 1000);
        //}
        public int Save(User user)
        {
            //save user to database
            Console.WriteLine($"Saved user {user.FirstName} {user.LastName}");
            //return the new identifier
            return id++;
        }

        /// <summary>
        /// Updates a user in the database
        /// </summary>
        public int Update(User user)
        {
            //update the user in the database
            Console.WriteLine($"Updated user with id: {user.Id}");
            //return the user id of the update user
            return user.Id;
        }

        /// <summary>
        /// Delete a user in the database
        /// </summary>
        public int Delete(User user)
        {
            //delete the user from the database
            Console.WriteLine($"Deleted user with id: {user.Id}");
            return user.Id;
        }

        /// <summary>
        /// Fetch a user from the database
        /// </summary>
        public User GetUser(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine($"Fetching user with id: {userId}");

            // used only for mocking purposes in brownbag
            return new User()
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
        }
    }
}
