using Microsoft.AspNetCore.Mvc;
using StudentsSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsSystem.Web.Controllers
{
    public class DisciplinesController : Controller
    {
        private readonly IDIsciplineService disciplineService;

        public DisciplinesController(IDIsciplineService disciplineService)
        {
            this.disciplineService = disciplineService;
        }

        public async Task<IActionResult> DisciplinesList()
        {
            var view = await this.disciplineService.GetAllDisciplines();
            return View(view);
        }
    }
}
