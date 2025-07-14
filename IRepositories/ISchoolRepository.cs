using school_management_api.Models;

namespace school_management_api.IRepositories
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetSchoolsAsync();
        Task<School> GetSchoolByIdAsync(int id);
        Task<School>AddSchoolAsync(School school);
        Task<School> UpdateSchoolAsync(int id,School school);
        Task<bool> DeleteSchoolAsync(int id);

    }
}
