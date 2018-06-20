using UserRegistration.Models;

namespace UserRegistration.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
        void Delete(User user);
        User GetById(int userId);
    }
}
