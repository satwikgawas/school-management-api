using school_management_api.Models;
using System.ComponentModel.DataAnnotations;

namespace school_management_api.Schemas
{
    public class StudentListResponse
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentEmail { get; set; }

        public string StudentMobNo { get; set; }
        public int SchoolId { get; set; }
    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentEmail { get; set; }

        public string StudentMobNo { get; set; }
        public School School { get; set; }
    }

    public class StudentPOSTRequest
    {
        [Required(ErrorMessage = "Student name is required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Student age is required")]
        public int StudentAge { get; set; }
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [Required(ErrorMessage = "Student email is required")]
        public string StudentEmail { get; set; }
        [Phone(ErrorMessage = "Please enter valid mobile no")]
        [Required(ErrorMessage = "Student mobile no is required")]
        public string StudentMobNo { get; set; }
        [Required(ErrorMessage = "School id is required")]
        public int SchoolId { get; set; }
    }

    public class StudentPUTRequest
    {
        [Required(ErrorMessage = "Student id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Student name is required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Student age is required")]
        public int StudentAge { get; set; }
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [Required(ErrorMessage = "Student email is required")]
        public string StudentEmail { get; set; }
        [Phone(ErrorMessage = "Please enter valid mobile no")]
        [Required(ErrorMessage = "Student mobile no is required")]
        public string StudentMobNo { get; set; }
        [Required(ErrorMessage = "School id is required")]
        public int SchoolId { get; set; }
    }
}
