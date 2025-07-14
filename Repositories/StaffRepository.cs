using Microsoft.EntityFrameworkCore;
using school_management_api.Data;
using school_management_api.IRepositories;
using school_management_api.Models;

namespace school_management_api.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>>GetStaffsAsync()
        {
            return await _context.Staffs.ToListAsync();
        }
        public async Task<IEnumerable<Staff>> GetStaffsWithSchoolAsync()
        {
            return await _context.Staffs.Include(sc => sc.School).ToListAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }
        public async Task<Staff> GetStaffByIdWithSchoolAsync(int id)
        {
            return await _context.Staffs.Include(sc => sc.School).SingleOrDefaultAsync(sf => sf.Id == id);
        }

        public async Task<Staff> AddStaffAsync(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff> UpdateStaffAsync(int id, Staff staff)
        {
            var staffEntity = await _context.Staffs.FindAsync(id);
            if (staffEntity == null)
            {
                return null;
            }

            staffEntity.StaffName= staff.StaffName;
            staffEntity.StaffEmail= staff.StaffEmail;
            staffEntity.Designation = staff.Designation;
            staffEntity.SchoolId = staff.SchoolId;

            await _context.SaveChangesAsync();
            return staffEntity;
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return false;
            }

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
