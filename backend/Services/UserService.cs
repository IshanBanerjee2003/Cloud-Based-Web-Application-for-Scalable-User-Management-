using System.Collections.Generic;
using backend.Models;

namespace backend.Services
{
    public class UserService
    {
        private static List<User> users = new List<User>();

        public List<User> GetUsers()
        {
            return users;
        }

        public void AddUser(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
        }

        public User UpdateUser(int id, User updatedUser)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
                return null;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user != null)
                users.Remove(user);
        }
    }
}
