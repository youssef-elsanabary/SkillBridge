using Backend.Context;
using Backend.Models;
using global::Backend.Context;
using global::Backend.Models;
using System.Collections.Generic;
using System.Linq;
namespace Backend.Repository
{
        public class UserRepository : IUserRepository
        {
            private readonly AppDbContext _context;

            public UserRepository(AppDbContext context)
            {
                _context = context;
            }

            public IEnumerable<User> GetUsers()
            {
                return _context.Users.ToList();
            }

            public User GetUserById(int id)
            {
                return _context.Users.Find(id);
            }

            public void AddUser(User user)
            {
                _context.Users.Add(user);
            }

            public void UpdateUser(User user)
            {
                _context.Users.Update(user);
            }

            public void DeleteUser(int id)
            {
                var user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                }
            }

            public void Save()
            {
                _context.SaveChanges();
            }
        }
    }


