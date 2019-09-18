using BusinessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TestMG.Web.ServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<IList<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeAsync();
    }
}