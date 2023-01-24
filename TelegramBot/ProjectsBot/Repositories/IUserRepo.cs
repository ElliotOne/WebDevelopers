using ProjectsBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBot.Repositories
{
    public interface IUserRepo
    {
        bool IsUserExist(string username);
        void Save();
        void RegisterUserName(string username);
        void RegisterPassword(string username,string password);
        void RegisterFullName(string username, string fullname);
        void RegisterContact(string username, string contact);
    }
}
