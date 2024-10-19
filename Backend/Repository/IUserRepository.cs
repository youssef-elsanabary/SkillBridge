using Backend.Models;
using global::Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
        public interface IUserRepository
        {
            IEnumerable<User> GetUsers();
            User GetUserById(int id);
            void AddUser(User user);
            void UpdateUser(User user);
            void DeleteUser(int id);
            void Save();
        }
    }


