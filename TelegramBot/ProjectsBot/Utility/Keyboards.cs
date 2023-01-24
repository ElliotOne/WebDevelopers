using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace ProjectsBot.Utility
{
    public static class Keyboards
    {
        public static string[] DefaultKeyboardButtons =
            {"پیگیری سفارش من", "سفارش جدید","پروفایل","همه ی سفارش های من","ورود / ثبتنام", "پشتیبانی", "وبسایت", "درباره ما"};

        public static string[] UserRegisterationKeyboardButtons =
            {"ورود","ثبتنام","بازگشت"};
        public static ReplyKeyboardMarkup DefaultKeyboard()
        {
            var rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard =
                new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(DefaultKeyboardButtons[0]),
                        new KeyboardButton(DefaultKeyboardButtons[1])
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(DefaultKeyboardButtons[2]),
                        new KeyboardButton(DefaultKeyboardButtons[3])
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(DefaultKeyboardButtons[4])
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(DefaultKeyboardButtons[5]),
                        new KeyboardButton(DefaultKeyboardButtons[6]),
                        new KeyboardButton(DefaultKeyboardButtons[7])
                    }
                };
            return rkm;
        }
        public static ReplyKeyboardMarkup Back()
        {
            var rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard =
                new KeyboardButton[][]
                {
                 new KeyboardButton[]
                 {
                     new KeyboardButton("بازگشت")
                 }
                };
            return rkm;
        }


        public static ReplyKeyboardMarkup UserRegisterationKeyboard()
        {
            var rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard =
                new KeyboardButton[][]
                {
                 new KeyboardButton[]
                 {
                     new KeyboardButton(UserRegisterationKeyboardButtons[0]),
                 },
                 new KeyboardButton[]
                 {
                     new KeyboardButton(UserRegisterationKeyboardButtons[1]),
                 },
                 new KeyboardButton[]
                 {
                     new KeyboardButton(UserRegisterationKeyboardButtons[2]),
                 }
                };
            return rkm;
        }

        //public static ReplyKeyboardMarkup RegisterStep1()
        //{
        //    var rkm = new ReplyKeyboardMarkup();
        //    rkm.Keyboard =
        //    new KeyboardButton[][]
        //    {
        //         new KeyboardButton[]
        //         {
        //             new KeyboardButton("شروع سفارش")
        //         },
        //         new KeyboardButton[]
        //         {
        //             new KeyboardButton("بازگشت")
        //         }
        //    };
        //    return rkm;
        //}


        //public static ReplyKeyboardMarkup UserRegisterationKeyboard()
        //{

        //}

    }
}
