using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusinessLayer.Entities;
using Moq;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessLayerTest
{
    [TestClass]
    public class EmployeesTest
    {
        IEnumerable<EmployeeDTO> expectedEmployees;
        IEnumerable<BaseEmployee> expectedEmployeesEntities;
        Mock<IEmployeeRepository> mockEmployeeRepository;
        Mock<IEmployeeService> mockEmployeeService;
        EmployeeService employeeService;

        [TestInitialize]
        public void InitialiazeTestData()
        {

            //Setup test data
            expectedEmployees = GetExpectedEmployees();
            expectedEmployeesEntities = GetExpectedEmployeesEntities();

            mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository.Setup(m => m.GetAll()).Returns(Task.FromResult(expectedEmployeesEntities));
            employeeService = new EmployeeService(mockEmployeeRepository.Object);

            mockEmployeeService.Setup( m => m.GetEmployees()).Returns(Task.FromResult(expectedEmployees));
        }

        [TestMethod]
        public void GetSalaryEmployees()
        {

            var actualEmployees = employeeService.GetEmployees().Result;

            //Assert
            EmployeeDTO hourlyEmployee = actualEmployees.Where(s => s.Id == 1).FirstOrDefault();
            EmployeeDTO monthlyEmployee = actualEmployees.Where(s => s.Id == 2).FirstOrDefault();
            Assert.IsTrue(hourlyEmployee.AnnualSalary == 86400000);
            Assert.IsTrue(monthlyEmployee.AnnualSalary == 960000);


        }

        private static IEnumerable<EmployeeDTO> GetExpectedEmployees()
        {
            return new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id= 1,
                    Name= "Juan",
                    ContractTypeName= "HourlySalaryEmployee",
                    RoleId= "1",
                    RoleName= "Administrator",
                    RoleDescription= null,
                    AnnualSalary= 86400000
                    
                },
                new EmployeeDTO()
                {
                    Id = 2,
                    Name = "Sebastian",
                    ContractTypeName= "MonthlySalaryEmployee",
                    RoleId= "2",
                    RoleName= "Contractor",
                    RoleDescription= null,
                    AnnualSalary= 960000
                   
                }
            }.AsEnumerable();
        }


        private static IEnumerable<BaseEmployee> GetExpectedEmployeesEntities()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id= 1,
                    Name= "Juan",
                    ContractTypeName= "HourlySalaryEmployee",
                    RoleId= "1",
                    RoleName= "Administrator",
                    RoleDescription= null,
                    HourlySalary= 60000,
                    MonthlySalary =80000

                },
                new Employee()
                {
                    Id = 2,
                    Name = "Sebastian",
                    ContractTypeName= "MonthlySalaryEmployee",
                    RoleId= "2",
                    RoleName= "Contractor",
                    HourlySalary= 60000,
                    MonthlySalary =80000

                }
            }.AsEnumerable();
        }
    }
}
