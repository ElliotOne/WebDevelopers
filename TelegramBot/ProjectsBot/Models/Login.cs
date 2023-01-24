using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectsBot.Models
{
    public class Login
    {
        public int Id { get; set; }

        //Relation To Users Table
        public string UserName { get; set; }

        public int TelId { get; set; }
        public bool IsLoggedIn { get; set; }



        //Relation To Project Table
        public string CurrnetProjectId { get; set; }

        public LoginSteps LoginSteps { get; set; }
        public BotForms BotForms { get; set; }

        public UserRegisterationSteps UserRegisterationSteps { get; set; }
        public ProjectRegisterationSteps ProjectRegisterationSteps { get; set; }
    }
    public enum LoginSteps
    {
        NotStarted,
        UserName,
        Password,
        Finished
    }

    public enum BotForms
    {
        None, // هیجکدام
        ProjectRegisteration, //سفارش
        Pursuitation, // پیگیری
        UserLogin, //ورود
        UserRegisteration //ثبت نام
    }

    public enum UserRegisterationSteps
    {
        NotStarted,
        UserName,
        Password,
        FullName,
        Contact,
        Finished
    }


    public enum ProjectRegisterationSteps
    {
        NotStarted,

        Title,
        Time,
        Price,
        Description,
        DescriptionFile,

        Finished
    }
}
