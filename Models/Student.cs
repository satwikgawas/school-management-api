using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_management_api.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentEmail { get; set; }
        public string StudentMobNo { get; set; }
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School? School { get; set; }
    }
}
