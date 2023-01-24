using CURDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CURDOperations.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly APIDbContext _appDBContext;
        public EmployeeRepository(APIDbContext aPIDbContext)
        {
            _appDBContext = aPIDbContext;
        }
        public bool DeleteEmployee(int ID)
        {
            bool result = false;
            var department = _appDBContext.employees.Find(ID);
            if (department != null)
            {
                _appDBContext.Entry(department).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<Employee> GetEmployeeByID(int ID)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _appDBContext.employees.FindAsync(ID);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<Employee> GetEmployees()
        {
            return _appDBContext.employees.ToList();
        }

        public Employee InsertEmployee(Employee objEmployee)
        {
            _appDBContext.employees.Add(objEmployee);
            _appDBContext.SaveChangesAsync();
            return objEmployee;
        }

        public async Task<Employee> UpdateEmployee(Employee objEmployee)
        {
            _appDBContext.Entry(objEmployee).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objEmployee;
        }
    }
}
