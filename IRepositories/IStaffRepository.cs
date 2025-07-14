using school_management_api.Models;

namespace school_management_api.IRepositories
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetStaffsAsync();
        Task<IEnumerable<Staff>> GetStaffsWithSchoolAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task<Staff> GetStaffByIdWithSchoolAsync(int id);
        Task<Staff>AddStaffAsync(Staff staff);
        Task<Staff> UpdateStaffAsync(int id, Staff staff);
        Task<bool> DeleteStaffAsync(int id);
    }
}
