using ProjectsBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBot.Repositories
{
    public interface ILoginRepo
    {
        void SetLoginStep(int TelId, LoginSteps loginSteps);
        LoginSteps GetLoginStep(int TelId);

        void SetCurrentForm(int TelId, BotForms botForms);
        BotForms GetCurrentForm(int TelId);


        void AddCurrentUser(int TelId);
        bool IsCurrnentUserExist(int TelId);

        bool CanLogin(int TelId, string password);

        bool IsCurrentUserLoggedIn(int TelId);
        void Save();
        void SetUserName(int TelId,string username);
        void ClearUserName(int TelId, string username);
        string GetUserProfile(int TelId);


        //Registration Methods
        void SetRegisterationStep(int TelId, UserRegisterationSteps userRegisterationSteps);
        UserRegisterationSteps GetRegistrationStep(int TelId);
        string GetUserName(int TelId);

       
        
        //Project Registration Methods
        void SetProjRegisterationStep(int TelId, ProjectRegisterationSteps projectRegisterationSteps);
        ProjectRegisterationSteps GetProjectRegisterationStep(int TelId);
        void SetCurrentUserProjectId(int TelId);
        string GetCurrentUserProjectId(int TelId);



        //Clear Methods For Back Button
        void ClearUser(int TelId);
        void ClearProjectRegisteration(int TelId);
        void ClearUserLoginState(int TelId);
    }
}
