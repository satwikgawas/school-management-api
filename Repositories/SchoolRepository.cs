using Microsoft.EntityFrameworkCore;
using school_management_api.Data;
using school_management_api.IRepositories;
using school_management_api.Models;

namespace school_management_api.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationDbContext _context;

        public SchoolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<School>> GetSchoolsAsync()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> GetSchoolByIdAsync(int id)
        {
            return await _context.Schools.FindAsync(id);
        }

        public async Task<School> AddSchoolAsync(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<School> UpdateSchoolAsync(int id, School school)
        {
            var schoolEntity = await _context.Schools.FindAsync(id);
            if (schoolEntity == null)
            {
                return null;
            }

            schoolEntity.SchoolName = school.SchoolName;
            schoolEntity.SchoolAddress = school.SchoolAddress;

            await _context.SaveChangesAsync();
            return schoolEntity;
        }

        public async Task<bool> DeleteSchoolAsync(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return false;
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
