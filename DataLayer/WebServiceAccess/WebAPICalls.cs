using BusinessLayer.Entities;
using DataLayer.WebServiceAccess.Base;
using DatataLayer.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataLayer.WebServiceAccess
{
    public class _webApiCalls : WebApiCallsBase, IWebApiCalls
    {
        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            return await GetItemListAsync<Employee>(EmployeeBaseUri);
        }

    }
}
