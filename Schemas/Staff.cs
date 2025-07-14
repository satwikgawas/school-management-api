using school_management_api.Models;
using System.ComponentModel.DataAnnotations;

namespace school_management_api.Schemas
{
    public class StaffListResponse
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
        public string Designation { get; set; }
        public int SchoolId { get; set; }
    }
    public class StaffResponse
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
        public string Designation { get; set; }
        public School School { get; set; }
    }

    public class StaffPOSTRequest
    {
        [Required(ErrorMessage = "Staff name is required")]
        public string StaffName { get; set; }
        [Required(ErrorMessage = "Staff email is required")]
        public string StaffEmail { get; set; }
        [Required(ErrorMessage = "Staff designation is required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "School id is required")]
        public int SchoolId { get; set; }
    }

    public class StaffPUTRequest
    {
        [Required(ErrorMessage = "Staff id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Staff name is required")]
        public string StaffName { get; set; }
        [Required(ErrorMessage = "Staff email is required")]
        public string StaffEmail { get; set; }
        [Required(ErrorMessage = "Staff designation is required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "School id is required")]
        public int SchoolId { get; set; }
    }
}
