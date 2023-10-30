using Ex1;

namespace Repository
{
    public interface IuserRepository
    {
        User addUser(User user);
        User getUserByEmailandPassword(string email, string password);
        void updetUser(int id, User userToUpdate);
    }
}