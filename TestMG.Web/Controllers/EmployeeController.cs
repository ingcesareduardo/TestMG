using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TestMG.Web.Models;
using TestMG.Web.ServiceAccess.Base;
using System.Linq;

namespace TestMG.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;


        public EmployeeController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> EmployeesView(int? id)
        {
            EmployeeIndexViewModel employeeIndexViewModel = new EmployeeIndexViewModel();
            var employees = await _webApiCalls.GetEmployeesAsync();

            if (id != null)
                employees = employees.Where(e => e.Id == id).ToList();

            employeeIndexViewModel.Employees = employees;
            return PartialView("_Employees", employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
