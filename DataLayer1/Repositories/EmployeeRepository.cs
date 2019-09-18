using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataLayer.ServiceAccess.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IWebApiCalls _webApiCalls;

        public EmployeeRepository(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }
        public async Task<IEnumerable<BaseEmployee>> GetAll()
        {
            return await _webApiCalls.GetEmployeesAsync();
        }
    }
}
