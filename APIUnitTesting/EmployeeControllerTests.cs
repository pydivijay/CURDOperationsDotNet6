using CURDOperations.Controllers;
using CURDOperations.Models;
using CURDOperations.Repository;
using Moq;

namespace APIUnitTesting
{
    public class EmployeeControllerTests
    {

        private readonly Mock<IEmployeeRepository> employeeRepository;
        public EmployeeControllerTests()
        {
            employeeRepository = new Mock<IEmployeeRepository>();
        }
        [Fact]
        public void Get_EmployeeList()
        {
            //arrange
            var employeeList = GetEmployees();
            employeeRepository.Setup(x => x.GetEmployees()).Returns(employeeList);

            var employeeController = new EmployeeController(employeeRepository.Object);

            //act
            var employeeResult = employeeController.Get();

            // assert
            Assert.NotNull(employeeResult);
            Assert.Equal(GetEmployees().Count(), employeeResult.Count());
            Assert.Equal(GetEmployees().ToString(), employeeResult.ToString());
            Assert.True(employeeList.Equals(employeeResult));

        }

        [Fact]
        public void Insert_Employee()
        {//arrange
            var employeeList = GetEmployees();
            employeeRepository.Setup(x => x.InsertEmployee(employeeList[1])).Returns(employeeList[1]);
            var employeeController = new EmployeeController(employeeRepository.Object);

            //act
            var employeeResult = employeeController.Post(employeeList[1]);
            //assert
            Assert.NotNull(employeeResult);
            Assert.Equal(employeeList[1].EmployeeID, employeeResult.EmployeeID);
            Assert.True(employeeList[1].EmployeeID == employeeResult.EmployeeID);
        }

        private List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    EmailId="vijay@gmail.com",
                    EmployeeName="vijay",
                    Department="it",
                    DOJ=DateTime.Now,
                },
                new Employee
                {
                     EmployeeID = 2,
                    EmailId="kumar@gmail.com",
                    EmployeeName="kumar",
                    Department="it",
                    DOJ=DateTime.Now,
                }
            };

            return employees;
        }
    }
}