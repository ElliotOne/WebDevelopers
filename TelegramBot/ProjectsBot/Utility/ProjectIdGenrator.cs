using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBot.Utility
{
    static class ProjectIdGenrator
    {
        public static string GenerateId()
        {

            Random random = new Random();
            int num = random.Next(1000000000, int.MaxValue);
            return num.ToString();
        }
        
    }
}
