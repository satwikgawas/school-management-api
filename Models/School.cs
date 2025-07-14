using System.ComponentModel.DataAnnotations;

namespace school_management_api.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        public string SchoolName { get; set; }
       
        public string SchoolAddress { get; set; }
        ICollection<Student>? Students { get; set; }
        ICollection<Staff>? Staffs { get; set; }
    }
}
