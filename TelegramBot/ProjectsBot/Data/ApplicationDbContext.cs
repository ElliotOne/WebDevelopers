using Microsoft.EntityFrameworkCore;
using ProjectsBot.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProjectsBot.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext():base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string con = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //optionsBuilder.UseSqlServer(con);



            //Use For Migrations
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-SF1M583\SQLSERVER17;DataBase = WebDevsBotDB;Trusted_Connection = True");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
