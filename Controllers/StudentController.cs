using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_management_api.IRepositories;
using school_management_api.Models;
using school_management_api.Schemas;

namespace school_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet("getStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentRepository.GetStudentsAsync();

            var studentListResponse = students.Select(student => new StudentListResponse
            {
                Id = student.Id,
                StudentName = student.StudentName,
                StudentAge = student.StudentAge,
                StudentEmail = student.StudentEmail,
                StudentMobNo = student.StudentMobNo,
                SchoolId = student.SchoolId
            });

            return Ok(studentListResponse);
        }

        [HttpGet("getStudetsWithSchool")]
        public async Task<IActionResult> GetStudentsWithSchool()
        {
            var students = await studentRepository.GetStudentsWithSchoolAsync();

            var studentResponse = students.Select(student => new StudentResponse
            {
                Id = student.Id,
                StudentName = student.StudentName,
                StudentAge = student.StudentAge,
                StudentEmail = student.StudentEmail,
                StudentMobNo = student.StudentMobNo,
                School = student.School
            });

            return Ok(studentResponse);
        }

        [HttpGet("getStudentById/{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound(new { Message = $"Student with Id {id} not found." });
            }
            var studentListResponse = new StudentListResponse
            {
                Id = student.Id,
                StudentName = student.StudentName,
                StudentAge = student.StudentAge,
                StudentEmail = student.StudentEmail,
                StudentMobNo = student.StudentMobNo,
                SchoolId = student.SchoolId
            };
            return Ok(studentListResponse);
        }

        [HttpGet("getStudentByIdWithSchool/{id:int}")]
        public async Task<IActionResult> GetStudentByIdWithSchoolAsync(int id)
        {
            var student = await studentRepository.GetStudentByIdWithSchoolAsync(id);
            if (student == null)
            {
                return NotFound(new { Message = $"Student with Id {id} not found." });
            }
            var studentResponse = new StudentResponse
            {
                Id = student.Id,
                StudentName = student.StudentName,
                StudentAge = student.StudentAge,
                StudentEmail = student.StudentEmail,
                StudentMobNo = student.StudentMobNo,
                School = student.School
            };
            return Ok(studentResponse);
        }

        [HttpPost("addStudent")]
        public async Task<IActionResult> AddStudent(StudentPOSTRequest studentPOSTRequest)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    StudentName = studentPOSTRequest.StudentName,
                    StudentAge = studentPOSTRequest.StudentAge,
                    StudentEmail = studentPOSTRequest.StudentEmail,
                    StudentMobNo = studentPOSTRequest.StudentMobNo,
                    SchoolId = studentPOSTRequest.SchoolId
                };
                var result = await studentRepository.AddStudentAsync(student);
                var studentResponse = new StudentResponse
                {
                    Id = result.Id,
                    StudentName = result.StudentName,
                    StudentAge = result.StudentAge,
                    StudentEmail = result.StudentEmail,
                    StudentMobNo = result.StudentMobNo,
                    School = student.School
                };
                return CreatedAtAction(nameof(GetStudentByIdWithSchoolAsync), new { id = studentResponse.Id }, studentResponse);
            }
            return BadRequest(studentPOSTRequest);
        }

        [HttpPut("updateStudent/{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentPUTRequest studentPUTRequest)
        {
            if (id != studentPUTRequest.Id)
            {
                return BadRequest("Id are not matching");
            }
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    StudentName = studentPUTRequest.StudentName,
                    StudentAge = studentPUTRequest.StudentAge,
                    StudentEmail = studentPUTRequest.StudentEmail,
                    StudentMobNo = studentPUTRequest.StudentMobNo,
                    SchoolId = studentPUTRequest.SchoolId
                };
                var result = await studentRepository.UpdateStudentAsync(id, student);
                var studentResponse = new StudentResponse
                {
                    Id = result.Id,
                    StudentName = result.StudentName,
                    StudentAge = result.StudentAge,
                    StudentEmail = result.StudentEmail,
                    StudentMobNo = result.StudentMobNo,
                    School =  result.School 
                };
                return Ok(studentResponse);
            }
            return BadRequest(studentPUTRequest);
        }

        [HttpDelete("deleteStudent/{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            bool success = await studentRepository.DeleteStudentAsync(id);
            if (!success)
            {
                return NotFound(new { Message = $"Student with Id {id} not found." });
            }
            return Ok(new { Message = "Deleted Successfully" });
        }
    }
}
