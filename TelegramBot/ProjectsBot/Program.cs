using ProjectsBot.Data;
using ProjectsBot.Models;
using ProjectsBot.Repositories;
using ProjectsBot.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Helpers;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace ProjectsBot
{
    class Program
    {
        static string token = ConfigurationManager.AppSettings.Get("BotApiKey");
        static string channelId = ConfigurationManager.AppSettings.Get("PrivateFilesChannelId");
        static bool isSendFileToChannel = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("SendFilesToChannel"));


        static TelegramBotClient botClient = new TelegramBotClient(token);

        static ApplicationDbContext _db = new ApplicationDbContext();

        private static IProjectRepo _IProjectRepo = new ProjectRepo(_db);
        public static IUserRepo _IUserRepo = new UserRepo(_db);
        public static ILoginRepo _ILoginRepo = new LoginRepo(_db);

        static string AboutUsInfo = InfoReader.Read("info/AboutUsInfo.txt");
        static string WebsiteInfo = InfoReader.Read("info/WebsiteInfo.txt");
        static string SupportInfo = InfoReader.Read("info/SupportInfo.txt");
        static void Main(string[] args)
        {


            botClient.StartReceiving();

            if (botClient.IsReceiving)
            {
                Console.WriteLine("Bot started ...");
            }


            botClient.OnMessage += Bot_OnMessage;



            Console.ReadLine();

            botClient.StopReceiving();
        }


     

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {

            var message = e.Message;

            if (message == null && message.Type != MessageType.Text) return;


            int UserTelId = message.From.Id;

            if (!message.From.IsBot)
            {
                if (!_ILoginRepo.IsCurrnentUserExist(UserTelId))
                {
                    _ILoginRepo.AddCurrentUser(UserTelId);
                    _ILoginRepo.Save();
                }

            }


            var whichForm = _ILoginRepo.GetCurrentForm(UserTelId);
            if (!message.From.IsBot && whichForm == BotForms.None)
            {
                //پیگیری سفارش من
                if (message.Text == Keyboards.DefaultKeyboardButtons[0])
                {
                    if (_ILoginRepo.IsCurrentUserLoggedIn(UserTelId))
                    {
                        _ILoginRepo.SetCurrentForm(UserTelId, BotForms.Pursuitation);
                        _ILoginRepo.Save();
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "کد پیگیری سفارش خود را وارد کنید : ",
                   ParseMode.Default, false, false, 0, Keyboards.Back());
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا به سیستم وارد شوید.",
              ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }
                }



                //سفارش
                else if (message.Text == Keyboards.DefaultKeyboardButtons[1])
                {
                    if (_ILoginRepo.IsCurrentUserLoggedIn(UserTelId))
                    {
                        _ILoginRepo.SetCurrentForm(UserTelId, BotForms.ProjectRegisteration);
                        _ILoginRepo.SetProjRegisterationStep(UserTelId, ProjectRegisterationSteps.Title);

                        _ILoginRepo.SetCurrentUserProjectId(UserTelId);

                        string projectId = _ILoginRepo.GetCurrentUserProjectId(UserTelId);
                        string username = _ILoginRepo.GetUserName(UserTelId);

                        _IProjectRepo.AddProject(username, projectId);
                        _IProjectRepo.Save();

                        _ILoginRepo.Save();
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "عنوان یا موضوع پروژه را وارد کنید :",
                   ParseMode.Default, false, false, 0, Keyboards.Back());
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا به سیستم وارد شوید.",
              ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }
                }

                //پروفایل
                else if (message.Text == Keyboards.DefaultKeyboardButtons[2])
                {
                    if (_ILoginRepo.IsCurrentUserLoggedIn(UserTelId))
                    {
                        var profile = _ILoginRepo.GetUserProfile(UserTelId);
                        var msg = "پروفایل شما" + "\n\n" + profile;

                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, msg,
             ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "پروفایل یافت نشد. شما باید ابتدا به سیستم وارد شوید.",
              ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }

                }


                //همه ی سفارش های من
                else if (message.Text == Keyboards.DefaultKeyboardButtons[3])
                {
                    if (_ILoginRepo.IsCurrentUserLoggedIn(UserTelId))
                    {
                        string username = _ILoginRepo.GetUserName(UserTelId);
                        var projects = _IProjectRepo.GetAllProjectsDetails(username);

                        foreach (var item in projects)
                        {
                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, item,
                   ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                        }

                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا به سیستم وارد شوید.",
              ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }
                }

                //ثبت نام / ورود
                else if (message.Text == Keyboards.DefaultKeyboardButtons[4])
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "گزینه مورد نظر خود را انتخاب کنید : ",
               ParseMode.Default, false, false, 0, Keyboards.UserRegisterationKeyboard());
                }



                //ورود
                else if (message.Text == Keyboards.UserRegisterationKeyboardButtons[0])
                {
                    _ILoginRepo.SetCurrentForm(UserTelId, BotForms.UserLogin);
                    _ILoginRepo.SetLoginStep(UserTelId, LoginSteps.UserName);
                    _ILoginRepo.Save();
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "نام کاربری را وارد کنید : ",
               ParseMode.Default, false, false, 0, Keyboards.Back());
                }

                //ثبتنام
                else if (message.Text == Keyboards.UserRegisterationKeyboardButtons[1])
                {
                    _ILoginRepo.SetCurrentForm(UserTelId, BotForms.UserRegisteration);
                    _ILoginRepo.SetRegisterationStep(UserTelId, UserRegisterationSteps.UserName);
                    _ILoginRepo.Save();
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "نام کاربری دلخواه خود را وارد کنید : ",
              ParseMode.Default, false, false, 0, Keyboards.Back());
                }



                //پشتیبانی
                else if (message.Text == Keyboards.DefaultKeyboardButtons[5])
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, SupportInfo, ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                }


                //وبسایت
                else if (message.Text == Keyboards.DefaultKeyboardButtons[6])
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, WebsiteInfo, ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());

                }

                //درباره ما
                else if (message.Text == Keyboards.DefaultKeyboardButtons[7])
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, AboutUsInfo, ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                }

                else
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "گزینه مورد نظر خود را انتخاب کنید : ",
                ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                }
            }
            else
            {

                if (message.Text == "بازگشت")
                {
                    if (whichForm == BotForms.ProjectRegisteration)
                    {
                        _ILoginRepo.ClearProjectRegisteration(UserTelId);
                        _ILoginRepo.SetProjRegisterationStep(UserTelId, ProjectRegisterationSteps.NotStarted);
                        _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                        _ILoginRepo.Save();
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "گزینه مورد نظر خود را انتخاب کنید : ",
               ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }
                    else if (whichForm == BotForms.Pursuitation)
                    {
                        _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                        _ILoginRepo.Save();
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "گزینه مورد نظر خود را انتخاب کنید : ",
               ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }
                    else if (whichForm == BotForms.UserRegisteration)
                    {
                        _ILoginRepo.ClearUser(UserTelId);
                        _ILoginRepo.Save();
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "گزینه مورد نظر خود را انتخاب کنید : ",
                ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                    }
                    else if (whichForm == BotForms.UserLogin)
                    {
                        _ILoginRepo.SetLoginStep(UserTelId, LoginSteps.NotStarted);
                        _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                        _ILoginRepo.ClearUserName(UserTelId, message.Text);
                        _ILoginRepo.ClearUserLoginState(UserTelId);
                        _ILoginRepo.Save();
                        await botClient.SendTextMessageAsync(e.Message.Chat.Id, "گزینه مورد نظر خود را انتخاب کنید : ",
               ParseMode.Default, false, false, 0, Keyboards.UserRegisterationKeyboard());
                    }
                }
                else
                {
                    //ProjectRegisteration
                    if (whichForm == BotForms.ProjectRegisteration)
                    {

                        string username = _ILoginRepo.GetUserName(UserTelId);
                        string projectId = _ILoginRepo.GetCurrentUserProjectId(UserTelId);

                        if (_ILoginRepo.GetProjectRegisterationStep(UserTelId) == ProjectRegisterationSteps.Title)
                        {
                            _IProjectRepo.RegisterTitle(username, message.Text, projectId);
                            _IProjectRepo.Save();

                            _ILoginRepo.SetProjRegisterationStep(UserTelId, ProjectRegisterationSteps.Time);
                            _ILoginRepo.Save();

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "مدت زمان مورد نظر شما برای انجام پروژه : ",
                  ParseMode.Default, false, false, 0, Keyboards.Back());
                        }
                        else if (_ILoginRepo.GetProjectRegisterationStep(UserTelId) == ProjectRegisterationSteps.Time)
                        {
                            _IProjectRepo.RegisterTime(username, message.Text, projectId);
                            _IProjectRepo.Save();

                            _ILoginRepo.SetProjRegisterationStep(UserTelId, ProjectRegisterationSteps.Price);
                            _ILoginRepo.Save();

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "محدوده قیمت مورد نظر شما برای انجام پروژه : ",
                  ParseMode.Default, false, false, 0, Keyboards.Back());
                        }
                        else if (_ILoginRepo.GetProjectRegisterationStep(UserTelId) == ProjectRegisterationSteps.Price)
                        {
                            _IProjectRepo.RegisterPrice(username, message.Text, projectId);
                            _IProjectRepo.Save();

                            _ILoginRepo.SetProjRegisterationStep(UserTelId, ProjectRegisterationSteps.Description);
                            _ILoginRepo.Save();

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "توضیحات و شرح پروژه مورد نظر : ",
                  ParseMode.Default, false, false, 0, Keyboards.Back());
                        }
                        else if (_ILoginRepo.GetProjectRegisterationStep(UserTelId) == ProjectRegisterationSteps.Description)
                        {
                            _IProjectRepo.RegisterDescription(username, message.Text, projectId);
                            _IProjectRepo.Save();

                            _ILoginRepo.SetProjRegisterationStep(UserTelId, ProjectRegisterationSteps.DescriptionFile);
                            _ILoginRepo.Save();

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "فایل توضیحات را ارسال کنید . در صورت موجود نبودن ، کلمه ندارد را ارسال کنید :",
                  ParseMode.Default, false, false, 0, Keyboards.Back());
                        }
                        else if (_ILoginRepo.GetProjectRegisterationStep(UserTelId) == ProjectRegisterationSteps.DescriptionFile)
                        {



                            if (e.Message.Type != MessageType.Text)
                            {

                                Task<Telegram.Bot.Types.File> file = null;

                                if (e.Message.Type == MessageType.Photo)
                                {
                                    file = botClient.GetFileAsync(e.Message.Photo[e.Message.Photo.Count() - 1].FileId);
                                }
                                else if(e.Message.Type == MessageType.Document)
                                {
                                    file = botClient.GetFileAsync(e.Message.Document.FileId);
                                }
                                else if (e.Message.Type == MessageType.Voice)
                                {
                                    file = botClient.GetFileAsync(e.Message.Voice.FileId);
                                }
                                else if (e.Message.Type == MessageType.Video)
                                {
                                    file = botClient.GetFileAsync(e.Message.Video.FileId);
                                }
                                else if (e.Message.Type == MessageType.Audio)
                                {
                                    file = botClient.GetFileAsync(e.Message.Audio.FileId);
                                }

                                if (isSendFileToChannel)
                                {
                                    await botClient.ForwardMessageAsync(channelId, e.Message.Chat.Id, e.Message.MessageId);
                                    await botClient.SendTextMessageAsync(channelId, _ILoginRepo.GetUserProfile(UserTelId));
                                }
                                else
                                {
                                    string path = @"files";
                                    try
                                    {
                                       
                                        var download_url = $"https://api.telegram.org/file/bot{token}/" + file.Result.FilePath;
                                        using (WebClient client = new WebClient())
                                        {
                                            client.DownloadFile(new Uri(download_url), path);
                                        }
                                    }
                                    catch{}
                                }


                                _IProjectRepo.RegisterDescriptionFile(username, file.Result.FilePath, projectId);
                                _IProjectRepo.Save();
                            }
                            else
                            {
                                _IProjectRepo.RegisterDescriptionFile(username, null , projectId);
                                _IProjectRepo.Save();
                            }
                            

                            _ILoginRepo.SetProjRegisterationStep(UserTelId, ProjectRegisterationSteps.Finished);
                            _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                            _ILoginRepo.Save();


                            string msg = _IProjectRepo.GetProjectDetials(username, projectId);

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "پروژه جدید با موفقیت ثبت گردید.");

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, msg,
                 ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());

                        }
                    }

                    //Pursuitation 
                    else if (whichForm == BotForms.Pursuitation)
                    {
                        string username = _ILoginRepo.GetUserName(UserTelId);
                        if (_IProjectRepo.IsProjectExist(username, message.Text))
                        {
                            ProjectStatus status = _IProjectRepo.GetProjectStatus(username, message.Text);
                            string msg = string.Empty;
                            switch (status)
                            {
                                case ProjectStatus.Finished:
                                    msg = "پروژه شما انجام شده و به زودی ارسال می گردد.";
                                    break;
                                case ProjectStatus.Accepted:
                                    msg = "پروژه شما پذیرفته شده و تا زمان مشخص شده انجام می گردد.";
                                    break;
                                case ProjectStatus.Rejected:
                                    msg = "پروژه شما تایید نگردید است.برای اطلاع بیشتر می توانید به پشتیبانی مراجعه کنید.";
                                    break;
                                case ProjectStatus.UnClear:
                                    msg = "پروژه شما تا کنون بررسی نگردیده است و وضعیت آن نا مشخص است.";
                                    break;
                            }

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, msg,
              ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                        }
                        else
                        {
                            string msg = "پروژه ای با کد رهگیری " + message.Text + " برای شما ثبت نشده است. ";
                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, msg,
               ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                        }

                        _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                        _ILoginRepo.Save();
                    }

                    //UserLogin
                    else if (whichForm == BotForms.UserLogin)
                    {

                        if (_ILoginRepo.GetLoginStep(UserTelId) == LoginSteps.UserName)
                        {
                            if (_IUserRepo.IsUserExist(message.Text))
                            {
                                _ILoginRepo.SetLoginStep(UserTelId, LoginSteps.Password);
                                _ILoginRepo.SetUserName(UserTelId, message.Text);
                                _ILoginRepo.Save();
                                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "کلمه عبور را وارد کنید :",
                ParseMode.Default, false, false, 0, Keyboards.Back());
                            }
                            else
                            {
                                _ILoginRepo.SetLoginStep(UserTelId, LoginSteps.NotStarted);
                                _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                                _ILoginRepo.Save();
                                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "نام کاربری یافت نشد.",
                  ParseMode.Default, false, false, 0, Keyboards.UserRegisterationKeyboard());
                            }
                        }
                        else if (_ILoginRepo.GetLoginStep(UserTelId) == LoginSteps.Password)
                        {

                            var isLoggedIn = _ILoginRepo.CanLogin(UserTelId, message.Text);
                            _ILoginRepo.Save();

                            if (isLoggedIn)
                            {
                                _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                                _ILoginRepo.Save();
                                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "شما با موفقیت وارد سیستم شد.",
               ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                            }
                            else
                            {
                                _ILoginRepo.SetLoginStep(UserTelId, LoginSteps.NotStarted);
                                _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                                _ILoginRepo.ClearUserName(UserTelId, message.Text);
                                _ILoginRepo.Save();
                                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "کلمه عبور اشتباه است.",
               ParseMode.Default, false, false, 0, Keyboards.UserRegisterationKeyboard());
                            }



                        }

                    }
                    //UserRegisteration
                    else if (whichForm == BotForms.UserRegisteration)
                    {
                        if (_ILoginRepo.GetRegistrationStep(UserTelId) == UserRegisterationSteps.UserName)
                        {
                            if (_IUserRepo.IsUserExist(message.Text))
                            {
                                _ILoginRepo.SetRegisterationStep(UserTelId, UserRegisterationSteps.NotStarted);
                                _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                                _ILoginRepo.Save();
                                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "نام کاربری در سیستم موجود است. امکان ثبتنام وجود ندارد.",
                ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                            }
                            else
                            {
                                _IUserRepo.RegisterUserName(message.Text);
                                _IUserRepo.Save();


                                _ILoginRepo.SetUserName(UserTelId, message.Text);
                                _ILoginRepo.SetRegisterationStep(UserTelId, UserRegisterationSteps.Password);
                                _ILoginRepo.Save();

                                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "رمز عبور دلخواه خود را وارد کنید :",
                  ParseMode.Default, false, false, 0, Keyboards.Back());
                            }
                        }
                        else if (_ILoginRepo.GetRegistrationStep(UserTelId) == UserRegisterationSteps.Password)
                        {
                            string username = _ILoginRepo.GetUserName(UserTelId);
                            _IUserRepo.RegisterPassword(username, message.Text);
                            _IUserRepo.Save();

                            _ILoginRepo.SetRegisterationStep(UserTelId, UserRegisterationSteps.FullName);
                            _ILoginRepo.Save();

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "نام و نام خانوادگی شما :",
                  ParseMode.Default, false, false, 0, Keyboards.Back());
                        }
                        else if (_ILoginRepo.GetRegistrationStep(UserTelId) == UserRegisterationSteps.FullName)
                        {
                            string username = _ILoginRepo.GetUserName(UserTelId);
                            _IUserRepo.RegisterFullName(username, message.Text);
                            _IUserRepo.Save();

                            _ILoginRepo.SetRegisterationStep(UserTelId, UserRegisterationSteps.Contact);
                            _ILoginRepo.Save();

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "اطلاعات تماس از قبیل شماره همراه ، آیدی تلگرام و ... :",
                  ParseMode.Default, false, false, 0, Keyboards.Back());
                        }
                        else if (_ILoginRepo.GetRegistrationStep(UserTelId) == UserRegisterationSteps.Contact)
                        {
                            string username = _ILoginRepo.GetUserName(UserTelId);
                            _IUserRepo.RegisterContact(username, message.Text);
                            _IUserRepo.Save();

                            _ILoginRepo.SetRegisterationStep(UserTelId, UserRegisterationSteps.Finished);

                            _ILoginRepo.SetCurrentForm(UserTelId, BotForms.None);
                            _ILoginRepo.Save();

                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "اطلاعات شما با موفقیت ثبت گردید. اکنون می توانید وارد شوید.",
                  ParseMode.Default, false, false, 0, Keyboards.DefaultKeyboard());
                        }
                    }
                }

            }

        }
    }
}
