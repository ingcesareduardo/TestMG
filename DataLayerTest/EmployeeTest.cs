using BusinessLayer.Interfaces;
using DataLayer.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class EmployeeTest
    {
        private IEmployeeRepository  _employeeRepository;
        [SetUp]
        public void Setup(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Test]
        public async void GetEmployees()
        {
            var employees = await _employeeRepository.GetAll();
            Assert.IsTrue(employees.Count() > 0);
        }
    }
}