using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectsBot.Data;
using ProjectsBot.Models;
using ProjectsBot.Utility;

namespace ProjectsBot.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private ApplicationDbContext _db;
        public ProjectRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddProject(string username, string projectId)
        {
            var user = _db.Users.First(u => u.UserName == username);

            Project proj = new Project()
            {
                ProjectId = projectId,
                User = user,
                ProjectStatus = ProjectStatus.UnClear
            };

            _db.Projects.Add(proj);
        }

        public ProjectStatus GetProjectStatus(string username, string projectId)
        {
            return _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId).ProjectStatus;
        }

        public bool IsProjectExist(string username, string projectId)
        {
            return _db.Projects.Include(u => u.User).Any(p => p.User.UserName == username && p.ProjectId == projectId);
        }




        public void RegisterTitle(string username, string title, string projectId)
        {
            _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId).Title = title;
        }

        public void RegisterPrice(string username, string price, string projectId)
        {
            _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId).Price = price;
        }

        public void RegisterTime(string username, string time, string projectId)
        {
            _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId).Time = time;
        }

        public void RegisterDescription(string username, string description, string projectId)
        {
            _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId).Description = description;
        }

        public void RegisterDescriptionFile(string username, string descriptionFile, string projectId)
        {
            _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId).DescriptionFile = descriptionFile;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public string GetProjectDetials(string username, string projectId)
        {


            var project = _db.Projects.Include(u => u.User).First(p => p.User.UserName == username && p.ProjectId == projectId);

            string res = "کد پیگیری پروژه : " + project.ProjectId +
                "\n\n💻 عنوان پروژه : \n\n" + project.Title +
                "\n\n⏱ زمان انجام پروژه :\n\n" + project.Time +
               "\n\n💵 مبلغ مورد نظر شما : \n\n" + project.Price +
               "\n\n📌 نیازمندی های پروژه :\n\n" + project.Description;

            return res;
        }

        public List<string> GetAllProjectsDetails(string username)
        {
            List<string> res = new List<string>();

            var projects = _db.Projects.Include(u => u.User).Where(p => p.User.UserName == username);
            foreach (var item in projects)
            {
                res.Add(GetProjectDetials(item.User.UserName, item.ProjectId));
            }

            return res;
        }
    }
}
