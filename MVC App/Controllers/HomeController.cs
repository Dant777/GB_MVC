using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Name = "Name#1", Position = "Position#1"},
                new Employee() {Name = "Name#2", Position = "Position#2"},
                new Employee() {Name = "Name#3", Position = "Position#3"},
                new Employee() {Name = "Name#4", Position = "Position#4"}
            };
            OfficeViewModel office = new OfficeViewModel(employees);
            return View(office);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}