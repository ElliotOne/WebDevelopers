using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectsBot.Utility
{
    public static class InfoReader
    {
        public static string Read(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                return "خطا : " + ex.Message;
            }
        }

    }
}
