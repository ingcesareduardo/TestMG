using BusinessLayer.Entities;
using Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMG.Web.ServiceAccess.Base;

namespace TestMG.Web.ServiceAccess
{
    public class _webApiCalls : WebApiCallsBase, IWebApiCalls 
    {
        public _webApiCalls(IServiceLocator settings) : base(settings)
        {


        }
        public async Task<IList<EmployeeDTO>> GetEmployeesAsync()
        {
            return await GetItemListAsync<EmployeeDTO>(EmployeeBaseUri);
        }

        public async Task<EmployeeDTO> GetEmployeeAsync()
        {
            return await GetItemAsync<EmployeeDTO>(EmployeeBaseUri);
        }

    }
}
