using Ex1;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;

namespace Service
{
    public class userService : IuserService
    {
        IuserRepository repository;
        public userService(IuserRepository repository)
        {
            this.repository = repository;
        }
        public User getUserByEmailandPassword(string email, string password)
        {
            return repository.getUserByEmailandPassword(email, password);
        }

        public User addUser(User user)
        {
            return repository.addUser(user);
        }

        public void updetUser(int id, User userToUpdate)
        {
            repository.updetUser(id, userToUpdate);

        }
        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;

        }

    }

}

