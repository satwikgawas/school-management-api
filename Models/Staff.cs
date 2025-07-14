using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_management_api.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail  { get; set; }
        public string Designation { get; set; }
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        
        public School? School { get; set; }
    }
}
