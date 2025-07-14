using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_management_api.IRepositories;
using school_management_api.Models;
using school_management_api.Schemas;

namespace school_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository staffRepository;
        public StaffController(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        [HttpGet("getStaffs")]
        public async Task<IActionResult> GetStaffs()
        {
            var staffs = await staffRepository.GetStaffsAsync();

            var staffListResponse = staffs.Select(staff => new StaffListResponse
            {
                Id = staff.Id,
                StaffName = staff.StaffName,
                StaffEmail = staff.StaffEmail,
                Designation = staff.Designation,
                SchoolId = staff.SchoolId
            });

            return Ok(staffListResponse);
        }

        [HttpGet("getStaffsWithSchool")]
        public async Task<IActionResult> GetStaffsWithSchool()
        {
            var staffs = await staffRepository.GetStaffsWithSchoolAsync();

            var staffResponse = staffs.Select(staff => new StaffResponse
            {
                Id = staff.Id,
                StaffName = staff.StaffName,
                StaffEmail = staff.StaffEmail,
                Designation = staff.Designation,
                School = staff.School
            });

            return Ok(staffResponse);
        }

        [HttpGet("getStaffById/{id:int}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await staffRepository.GetStaffByIdAsync(id);
            if (staff == null)
            {
                return NotFound(new { Message = $"Staff with Id {id} not found." });
            }
            var staffListResponse = new StaffListResponse
            {
                Id = staff.Id,
                StaffName = staff.StaffName,
                StaffEmail = staff.StaffEmail,
                Designation = staff.Designation,
                SchoolId = staff.SchoolId
            };
            return Ok(staffListResponse);
        }

        [HttpGet("getStaffByIdWithSchool/{id:int}")]
        public async Task<IActionResult> GetStaffByIdWithSchoolAsync(int id)
        {
            var staff = await staffRepository.GetStaffByIdWithSchoolAsync(id);
            if (staff == null)
            {
                return NotFound(new { Message = $"Staff with Id {id} not found." });
            }
            var staffResponse = new StaffResponse
            {
                Id = staff.Id,
                StaffName = staff.StaffName,
                StaffEmail = staff.StaffEmail,
                Designation = staff.Designation,
                School = staff.School
            };
            return Ok(staffResponse);
        }

        [HttpPost("addStaff")]
        public async Task<IActionResult> AddStaff(StaffPOSTRequest staffPOSTRequest)
        {
            if (ModelState.IsValid)
            {
                var staff = new Staff
                {
                    StaffName = staffPOSTRequest.StaffName,
                    StaffEmail = staffPOSTRequest.StaffEmail,
                    Designation = staffPOSTRequest.Designation,
                    SchoolId = staffPOSTRequest.SchoolId
                };
                var result = await staffRepository.AddStaffAsync(staff);
                var staffResponse = new StaffResponse
                {
                    Id = result.Id,
                    StaffName = result.StaffName,
                    StaffEmail = result.StaffEmail,
                    Designation = result.Designation,
                    School = result.School
                };
                return CreatedAtAction(nameof(GetStaffByIdWithSchoolAsync), new { id = staffResponse.Id }, staffResponse);
            }
            return BadRequest(staffPOSTRequest);
        }

        [HttpPut("updateStaff/{id:int}")]
        public async Task<IActionResult> UpdateStaff(int id, StaffPUTRequest staffPUTRequest)
        {
            if (id != staffPUTRequest.Id)
            {
                return BadRequest("Id are not matching");
            }
            if (ModelState.IsValid)
            {
                var staff = new Staff
                {
                    StaffName = staffPUTRequest.StaffName,
                    StaffEmail = staffPUTRequest.StaffEmail,
                    Designation = staffPUTRequest.Designation,
                    SchoolId = staffPUTRequest.SchoolId
                };
                var result = await staffRepository.UpdateStaffAsync(id, staff);
                var staffResponse = new StaffResponse
                {               
                    Id = result.Id,
                    StaffName = result.StaffName,
                    StaffEmail = result.StaffEmail,
                    Designation = result.Designation,
                    School = result.School
                };
                return Ok(staffResponse);
            }
            return BadRequest(staffPUTRequest);
        }

        [HttpDelete("deleteStaff/{id:int}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            bool success = await staffRepository.DeleteStaffAsync(id);
            if (!success)
            {
                return NotFound(new { Message = $"Staff with Id {id} not found." });
            }
            return Ok(new { Message = "Deleted Successfully" });
        }
    }
}
