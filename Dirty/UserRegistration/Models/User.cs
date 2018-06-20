namespace UserRegistration.Models
{
    public enum UserType
    {
        Speeker,
        Participant
    }

    public class User
    {
        private int id; //id
        private UserType userType; //Type of user
        private string firstName; // first name
        private string lasttName; // last name
        private string streetAddress; //steet address
        private string postalCode; //postal code
        private string city; //postal code
        private string emailAddress; // email
        private string phoneNumber; //phone number

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// User type
        /// </summary>
        public UserType UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName
        {
            get { return lasttName; }
            set { lasttName = value; }
        }


        /// <summary>
        /// Last name
        /// </summary>
        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }


        /// <summary>
        /// Last name
        /// </summary>
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        /// <summary>
        /// Last name
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// Last name
        /// </summary>
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }


        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set { phoneNumber = value; }
        }

    }
}
