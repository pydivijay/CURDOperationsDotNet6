using CURDOperations.Models;

namespace CURDOperations.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Task<Employee> GetEmployeeByID(int ID);
        Employee InsertEmployee(Employee objEmployee);
        Task<Employee> UpdateEmployee(Employee objEmployee);
        bool DeleteEmployee(int ID);
    }
}
