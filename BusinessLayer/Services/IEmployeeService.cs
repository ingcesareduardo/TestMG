using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();

        Task<EmployeeDTO> GetById(int id);
    }
}
