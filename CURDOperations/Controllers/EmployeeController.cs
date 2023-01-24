using CURDOperations.Models;
using CURDOperations.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CURDOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee ??
                throw new ArgumentNullException(nameof(employee));
        }
        [HttpGet]
        [Route("GetEmployee")]
        public List<Employee> Get()
        {
            return _employee.GetEmployees();
        }
        [HttpGet]
        [Route("GetEmployeeByID/{Id}")]
        public async Task<IActionResult> GetEmpByID(int Id)
        {
            return Ok(await _employee.GetEmployeeByID(Id));
        }
        [HttpPost]
        [Route("AddEmployee")]
        public Employee Post(Employee emp)
        {
            var result = _employee.InsertEmployee(emp);
            if (result.EmployeeID == 0)
            {
                return null;
            }
            return result;
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put(Employee emp)
        {
            await _employee.UpdateEmployee(emp);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _employee.DeleteEmployee(id);
            return new JsonResult("Deleted Successfully");
        }

        //[HttpGet]
        //[Route("GetDepartment")]
        //public async Task<IActionResult> GetAllDepartmentNames()
        //{
        //    return Ok(await _department.GetDepartment());
        //}
    }
}
