using Ex1;

namespace Service
{
    public interface IuserService
    {
        User addUser(User user);
        int checkPassword(string password);
        User getUserByEmailandPassword(string email, string password);
        void updetUser(int id, User userToUpdate);
    }
}