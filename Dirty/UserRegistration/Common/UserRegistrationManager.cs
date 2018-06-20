using System;
using System.Collections.Generic;
using System.Text;
using UserRegistration.Common;
using UserRegistration.Models;

namespace UserRegistration.Common
{
    public enum UserRegistrationAction
    {
        Create,
        Update,
        Delete,
    }

    public class UserRegistrationManager
    {
        private DatabaseManager databaseManager;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserRegistrationManager()
        {
            databaseManager = new DatabaseManager();
        }

        /// <summary>
        /// Based on action, save, update or delete user
        /// </summary>
        public int CreateUpdateOrDeleteUser(UserRegistrationAction action, User user)
        {
            int uid = -1;

            switch (action)
            {
                case UserRegistrationAction.Create:
                    if (UserValidationOk(user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.StreetAddress, user.PostalCode, user.City))
                    {
                        uid = databaseManager.Save(user);
                        break;
                    }
                    uid = -1;
                    break;
                case UserRegistrationAction.Update:
                    if (UserValidationOk(user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.StreetAddress, user.PostalCode, user.City))
                    {
                        uid = databaseManager.Update(user);
                        break;
                    }
                    uid = -1;
                    break;
                case UserRegistrationAction.Delete:
                    if (UserValidationOk(user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.StreetAddress, user.PostalCode, user.City))
                    {
                        databaseManager.Delete(user);
                        uid = 0;
                        break;
                    }
                    uid = -1;
                    break;
                default:
                    return -1;
            }

            switch (user.UserType)
            {
                case UserType.Participant:
                    SendPartEmailString(user.Id, user.FirstName, user.LastName, user.EmailAddress);
                    break;
                case UserType.Speeker:
                    SendSprEmailString(user.Id, user.FirstName, user.LastName, user.EmailAddress);
                    break;
            }
            return uid;
        }

        /// <summary>
        /// Get a user from the database
        /// </summary>
        /// <param name="theUsersId"></param>
        /// <returns></returns>
        public User FetchMeAUser(int theUsersId)
        {
            try
            {
                //get user from db

                //I tried to refactor this method but got tired so I stopped, code below could not be cleaned
                //User u = databaseManager.Get(id);
                //SetUserAttribs(u);
                //return u;
                var u = databaseManager.GetUser(theUsersId);
                return u;
            }
            catch (Exception e)
            {
                //someone complained about a null reference exception once or a bunch of once, cant really tell but..
                //I really feel that this should be handled by returning a new User, plus I am better friends with our boss than they are so I think it should be up to me to decide
                return new User();
            }
        }

        #region Validation things
        private bool UserValidationOk(string fName, string lName, string email, string phoneNbr, string streetAddr, string zipCode, string city)
        {
            var userValid = false;
            //Check that the user name has at least one character and is not unreasonably long
            if (fName.Length > 2 && fName.Length < 64)
            {
                if (lName.Length > 2 && lName.Length < 64)
                {
                    //Check that we emailaddress is not empty
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        // Check address info
                        if (!string.IsNullOrWhiteSpace(streetAddr) && !string.IsNullOrWhiteSpace(zipCode) &&
                            !string.IsNullOrWhiteSpace(city))
                        {
                            //check that phonenumber is not empty
                            //bug 11567, JD 2017-01-23
                            //if (phoneNbr != "") bug resolved, does not check for null or white space
                            if (!string.IsNullOrWhiteSpace(phoneNbr))
                            {
                                userValid = true;
                            }
                        }
                    }
                }
            }
            return userValid;
        }
        #endregion

        #region Email stuff
        private void SendPartEmailString(int uid, string fName, string lName, string emailAddr)
        {
            try
            {
                var handler = new EmailHandler();
                handler.EmailServerConnectionSetup();

                string s = $"Dear {fName} {lName} \n";
                s += "You are welcome to the super event you have registered for and we look forward to have you as a guest \n";
                s += "Please verify you attendance by clicking the email link below \n\n";
                s += $"www.somesortofbrownbagevent.com/guest/{uid} \n\n";
                s += "Best regards \n";
                s += "Admin";
                handler.SendEmail(s, emailAddr);
            }
            catch (Exception e)
            {
            }
        }

        private void SendSprEmailString(int uid, string fName, string lName, string emailAddr)
        {
            try
            {
                var handler = new EmailHandler();
                handler.EmailServerConnectionSetup();

                string s = $"Dear {fName} {lName} \n";
                s += "You are welcome to the super event you have registered for and we look forward to have you as a speaker \n";
                s += "Please verify you attendance by clicking the email link below \n\n";
                s += $"www.somesortofbrownbagevent.com/speaker/{uid} \n\n";
                s += "Best regards \n";
                s += "Admin";
                handler.SendEmail(s, emailAddr);
            }
            catch (Exception e)
            {
            }
        }

        #endregion
    }
}
