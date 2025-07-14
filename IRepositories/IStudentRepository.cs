using school_management_api.Models;

namespace school_management_api.IRepositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<IEnumerable<Student>> GetStudentsWithSchoolAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> GetStudentByIdWithSchoolAsync(int id);
        Task<Student>AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
