using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Service.Interfaces;
using InventoryManagement.Service.Models.Request;
using InventoryManagement.Web.Models;
using System.Diagnostics;

namespace InventoryManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeService employeeService;

        public HomeController(ILogger<HomeController> logger,
            IEmployeeService employeeService)
        {
            _logger = logger;
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var x = await this.employeeService.GetAllEmployeesAsync(new SearchRequest<string>());
            }
            catch (Exception ex)
            {

            }
            return View();
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
