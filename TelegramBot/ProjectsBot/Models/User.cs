using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBot.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
