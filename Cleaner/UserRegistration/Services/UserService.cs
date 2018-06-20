using UserRegistration.Interfaces;
using UserRegistration.Models;

namespace UserRegistration.Services
{

    public class UserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public void Save(User user)
        {
            user.Validate();
            _repository.Save(user);
        }

        public void Delete(User user)
        {
            user.Validate();
            _repository.Delete(user);
        }

        public User GetById(int userId)
        {
            return _repository.GetById(userId);
        }

    }
}
