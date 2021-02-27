using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsSystem.Services;
using StudentsSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TasksService taskService;

        public HomeController(ILogger<HomeController> logger, TasksService taskService)
        {
            _logger = logger;
            this.taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var model = await this.taskService.GetAllTasks();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
