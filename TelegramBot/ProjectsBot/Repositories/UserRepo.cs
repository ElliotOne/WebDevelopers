using ProjectsBot.Data;
using ProjectsBot.Models;
using ProjectsBot.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectsBot.Repositories
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext _db;
        public UserRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool IsUserExist(string username)
        {
            return _db.Users.Any(u => u.UserName.Equals(username, StringComparison.InvariantCulture));
        }

        public void RegisterContact(string username, string contact)
        {
            _db.Users.First(u => u.UserName == username).Contact = contact;
        }

        public void RegisterFullName(string username, string fullname)
        {
            _db.Users.First(u => u.UserName == username).FullName = fullname;
        }

        public void RegisterPassword(string username, string password)
        {
            _db.Users.First(u => u.UserName == username).Password = password;
        }

        public void RegisterUserName(string username)
        {
            User user = new User
            {
                UserName = username
            };

            _db.Users.Add(user);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}
