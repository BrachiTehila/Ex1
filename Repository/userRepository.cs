
using Ex1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class userRepository : IuserRepository
    {
        private readonly String pathFile = "M:\\Web Api\\Ex1\\Ex1\\data.txt";
        public User getUserByEmailandPassword(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == email && user.Password == password)
                        return user;
                }
            }
            return null;

        }

        public User addUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(pathFile).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(pathFile, userJson + Environment.NewLine);
            return user;
        }

        public void updetUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(pathFile);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(pathFile, text);
            }

        }

    }
}
