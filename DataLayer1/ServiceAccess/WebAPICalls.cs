using BusinessLayer.Entities;
using DataLayer.Configuration;
using DataLayer.ServiceAccess.Base;
using DatataLayer.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataLayer.WebServiceAccess
{
    public class _webApiCalls : WebApiCallsBase, IWebApiCalls 
    {
        public _webApiCalls(IServiceLocator settings) : base(settings)
        {


        }
        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            return await GetItemListAsync<Employee>(EmployeeBaseUri);
        }

    }
}
