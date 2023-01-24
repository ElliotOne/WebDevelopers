using ProjectsBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectsBot.Repositories
{
    public interface IProjectRepo
    {
        bool IsProjectExist(string username, string projectId);
        ProjectStatus GetProjectStatus(string username, string projectId);


       
        void Save();


        //Porject registration methods
        void AddProject(string username, string projectId);
        void RegisterTitle(string username, string title, string projectId);
        void RegisterTime(string username, string time, string projectId);
        void RegisterPrice(string username, string price, string projectId);
        void RegisterDescription(string username, string description, string projectId);
        void RegisterDescriptionFile(string username, string descriptionFile, string projectId);
        string GetProjectDetials(string username, string projectId);
        List<string> GetAllProjectsDetails(string username);
    }
}
