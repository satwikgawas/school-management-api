using Microsoft.EntityFrameworkCore;
using school_management_api.Data;
using school_management_api.IRepositories;
using school_management_api.Models;

namespace school_management_api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetStudentsWithSchoolAsync()
        {
            return await _context.Students.Include(sc=> sc.School).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }
        public async Task<Student> GetStudentByIdWithSchoolAsync(int id)
        {
            return await _context.Students.Include(sc => sc.School).SingleOrDefaultAsync(st=> st.Id==id);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var studentEntity = await _context.Students.FindAsync(id);
            if (studentEntity == null)
            {
                return null;
            }

            studentEntity.StudentName = student.StudentName;
            studentEntity.StudentAge = student.StudentAge;
            studentEntity.StudentEmail = student.StudentEmail;
            studentEntity.StudentMobNo = student.StudentMobNo;
            studentEntity.SchoolId = student.SchoolId;

            await _context.SaveChangesAsync();
            return studentEntity;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
