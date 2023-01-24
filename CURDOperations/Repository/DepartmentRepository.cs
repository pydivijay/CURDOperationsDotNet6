using CURDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CURDOperations.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly APIDbContext _aPIDbContext;
        public DepartmentRepository(APIDbContext aPIDbContext)
        {
            _aPIDbContext = aPIDbContext;
        }
        public bool DeleteDepartment(int ID)
        {
            bool result = false;
            var department = _aPIDbContext.departments.Find(ID);
            if (department != null)
            {
                _aPIDbContext.Entry(department).State = EntityState.Deleted;
                _aPIDbContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _aPIDbContext.departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByID(int ID)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _aPIDbContext.departments.FindAsync(ID);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Department> InsertDepartment(Department objDepartment)
        {
            _aPIDbContext.departments.Add(objDepartment);
            await _aPIDbContext.SaveChangesAsync();
            return objDepartment;
        }

        public async Task<Department> UpdateDepartment(Department objDepartment)
        {
            _aPIDbContext.Entry(objDepartment).State = EntityState.Modified;
            await _aPIDbContext.SaveChangesAsync();
            return objDepartment;
        }
    }
}
