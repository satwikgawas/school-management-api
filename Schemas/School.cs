using System.ComponentModel.DataAnnotations;

namespace school_management_api.Schemas
{
    public class SchoolResponse
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
    }

    public class SchoolPOSTRequest
    {
        [Required(ErrorMessage = "School name is required")]
        public string SchoolName { get; set; }
        [Required(ErrorMessage = "School address is required")]
        public string SchoolAddress { get; set; }
    }
    public class SchoolPUTRequest
    {
        [Required(ErrorMessage = "School id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "School name is required")]
        public string SchoolName { get; set; }
        [Required(ErrorMessage = "School address is required")]
        public string SchoolAddress { get; set; }
    }
}
