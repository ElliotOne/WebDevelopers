using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ProjectsBot.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public string Title { get; set; }
        public string ProjectId { get; set; }
        public string Description { get; set; }
        public string DescriptionFile { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
    }

    //Status will change by our programmers
    public enum ProjectStatus
    {
        Finished,
        Accepted ,
        Rejected ,
        UnClear
    } 
}