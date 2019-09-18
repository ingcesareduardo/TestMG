using BusinessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataLayer.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<IList<Employee>> GetEmployeesAsync();
    }
}