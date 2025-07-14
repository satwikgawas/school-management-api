using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_management_api.IRepositories;
using school_management_api.Models;
using school_management_api.Schemas;

namespace school_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository schoolRepository;
        public SchoolController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        [HttpGet]
        [Route("getSchools")]
        public async Task<IActionResult> GetSchools()
        {
            var schools = await schoolRepository.GetSchoolsAsync();

            var schoolResponseList = schools.Select(school => new SchoolResponse
            {
                Id = school.Id,
                SchoolName = school.SchoolName,
                SchoolAddress = school.SchoolAddress
            });

            return Ok(schoolResponseList);
        }

        [HttpGet("{id:int}")]
        [Route("getSchoolById")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            var school = await schoolRepository.GetSchoolByIdAsync(id);
            if (school == null)
            {
                return NotFound(new { Message = $"School with Id {id} not found." });
            }
            var schoolResponse = new SchoolResponse
            {
                Id = school.Id,
                SchoolName = school.SchoolName,
                SchoolAddress = school.SchoolAddress
            };
            return Ok(schoolResponse);
        }

        [HttpPost]
        [Route("addSchool")]
        public async Task<IActionResult> AddSchool(SchoolPOSTRequest schoolPOSTRequest)
        {
            if (ModelState.IsValid)
            {
                var school = new School
                {
                    SchoolName = schoolPOSTRequest.SchoolName,
                    SchoolAddress = schoolPOSTRequest.SchoolAddress
                };
                var result = await schoolRepository.AddSchoolAsync(school);
                var schoolResponse = new SchoolResponse
                {
                    Id = result.Id,
                    SchoolName = result.SchoolName,
                    SchoolAddress = result.SchoolAddress
                };
                return CreatedAtAction(nameof(GetSchoolById), new { id = schoolResponse.Id }, schoolResponse);
            }
            return BadRequest(schoolPOSTRequest);
        }

        [HttpPut("{id:int}")]
        [Route("updateSchool")]
        public async Task<IActionResult> UpdateSchool(int id, SchoolPUTRequest schoolPUTRequest)
        {
            if (id != schoolPUTRequest.Id)
            {
                return BadRequest("Id are not matching");
            }
            if (ModelState.IsValid)
            {
                var school = new School
                {
                    Id = schoolPUTRequest.Id,
                    SchoolName = schoolPUTRequest.SchoolName,
                    SchoolAddress = schoolPUTRequest.SchoolAddress
                };
                var result = await schoolRepository.UpdateSchoolAsync(id, school);
                var schoolResponse = new SchoolResponse
                {
                    Id = result.Id,
                    SchoolName = result.SchoolName,
                    SchoolAddress = result.SchoolAddress
                };
                return Ok(schoolResponse);
            }
            return BadRequest(schoolPUTRequest);
        }

        [HttpDelete("{id:int}")]
        [Route("delteSchool")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            bool success = await schoolRepository.DeleteSchoolAsync(id);
            if (!success)
            {
                return NotFound(new { Message = $"School with Id {id} not found." });
            }
            return Ok(new { Message = "Deleted Successfully" });       
        }
    }
}
