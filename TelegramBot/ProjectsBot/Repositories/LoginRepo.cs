using Microsoft.EntityFrameworkCore;
using ProjectsBot.Data;
using ProjectsBot.Models;
using ProjectsBot.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectsBot.Repositories
{
    public class LoginRepo : ILoginRepo
    {
        private ApplicationDbContext _db;
        public LoginRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public BotForms GetCurrentForm(int TelId)
        {
            return _db.Logins.First(l => l.TelId == TelId).BotForms;
        }

        public void SetCurrentForm(int TelId, BotForms botForms)
        {
            _db.Logins.First(l => l.TelId == TelId).BotForms = botForms;
        }

        public void SetLoginStep(int TelId, LoginSteps loginSteps)
        {
            _db.Logins.First(l => l.TelId == TelId).LoginSteps = loginSteps;
        }

        public LoginSteps GetLoginStep(int TelId)
        {
            return _db.Logins.First(l => l.TelId == TelId).LoginSteps;
        }

        public bool CanLogin(int TelId, string password)
        {
            var username = _db.Logins.First(l => l.TelId == TelId).UserName;
            var pass = _db.Users.First(u => u.UserName == username).Password;


            if (string.Equals(pass, password, StringComparison.InvariantCulture))
            {
                _db.Logins.First(l => l.TelId == TelId).IsLoggedIn = true;
                return true;
            }
            return false;
        }

        public void AddCurrentUser(int TelId)
        {
            Login login = new Login()
            {
                TelId = TelId,
            };
            _db.Logins.Add(login);
        }

        public bool IsCurrnentUserExist(int TelId)
        {
            return _db.Logins.Any(l => l.TelId == TelId);
        }

        public void SetUserName(int TelId, string username)
        {
            _db.Logins.First(l => l.TelId == TelId).UserName = username;
        }

        public void ClearUserName(int TelId, string username)
        {
            _db.Logins.First(l => l.TelId == TelId).UserName = null;
        }

        public bool IsCurrentUserLoggedIn(int TelId)
        {
            return _db.Logins.First(l => l.TelId == TelId).IsLoggedIn;
        }

        public string GetUserProfile(int TelId)
        {
            var username = _db.Logins.First(l => l.TelId == TelId).UserName;

            var user = _db.Users.First(u => u.UserName == username);

            string res = "نام و نام خانوادگی : " + "\n" + user.FullName + "\n"
                + "اطلاعات تماس : " + "\n" + user.Contact + "\n";

            return res;
        }

        public void SetRegisterationStep(int TelId, UserRegisterationSteps userRegisterationSteps)
        {
            _db.Logins.First(l => l.TelId == TelId).UserRegisterationSteps = userRegisterationSteps;
        }

        public UserRegisterationSteps GetRegistrationStep(int TelId)
        {
            return _db.Logins.First(l => l.TelId == TelId).UserRegisterationSteps;
        }

        public string GetUserName(int TelId)
        {
            return _db.Logins.First(l => l.TelId == TelId).UserName;
        }

        public void SetProjRegisterationStep(int TelId, ProjectRegisterationSteps projectRegisterationSteps)
        {
            _db.Logins.First(l => l.TelId == TelId).ProjectRegisterationSteps = projectRegisterationSteps;
        }

        public ProjectRegisterationSteps GetProjectRegisterationStep(int TelId)
        {
            return _db.Logins.First(l => l.TelId == TelId).ProjectRegisterationSteps;
        }

        public void SetCurrentUserProjectId(int TelId)
        {

            string projId = ProjectIdGenrator.GenerateId();
            while (_db.Projects.Any(p=>p.ProjectId == projId))
            {
                projId = ProjectIdGenrator.GenerateId();
            }

            _db.Logins.First(l => l.TelId == TelId).CurrnetProjectId = projId;
        }

        public string GetCurrentUserProjectId(int TelId)
        {
            return _db.Logins.First(l=>l.TelId == TelId).CurrnetProjectId;
        }

        public void ClearUser(int TelId)
        {
            var login = _db.Logins.First(l => l.TelId == TelId);
           
            var user = _db.Users.First(u => u.UserName == login.UserName);

            _db.Users.Remove(user);
            _db.Logins.Remove(login);
        }

        public void ClearProjectRegisteration(int TelId)
        {
            var projectId = GetCurrentUserProjectId(TelId);
            var username = GetUserName(TelId);

            var project = _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId);
            _db.Projects.Remove(project);
            _db.Logins.First(l => l.UserName == username).CurrnetProjectId = null;
        }

        public void ClearUserLoginState(int TelId)
        {
            _db.Logins.First(l => l.TelId == TelId).IsLoggedIn = false;
        }
    }
}
