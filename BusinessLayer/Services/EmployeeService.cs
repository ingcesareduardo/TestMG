using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessLayer.Base;
using System.Threading.Tasks;
using BusinessLayer.Entities;

namespace BusinessLayer.Services
{
    public class EmployeeService: IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            IList<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            var employees = await _employeeRepository.GetAll();
            employees.ToList().ForEach(x =>
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO = new MonthlyEmployeeCreator().EmployeeCreator(x);

                employeeDTOs.Add(employeeDTO);
            });
            return employeeDTOs;
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            var employees = await _employeeRepository.GetAll().ContinueWith(x => x.Result.Where(s => s.Id == id));
            var employee = employees.FirstOrDefault();

            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO = new MonthlyEmployeeCreator().EmployeeCreator(employee);

            return employeeDTO;
        }
    }
}
