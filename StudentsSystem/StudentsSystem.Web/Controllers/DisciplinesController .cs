using Microsoft.AspNetCore.Mvc;
using StudentsSystem.Data.Models;
using StudentsSystem.Services.Interfaces;
using StudentsSystem.Web.Model;
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
            var view = new DisciplinesListViewModel();
            var disciplines = await this.disciplineService.GetAllDisciplinesAsync();

            foreach (var discipline in disciplines)
            {
                Discipline d = new Discipline
                {
                    Id = discipline.Id,
                    Name = discipline.Name,
                    ProfessorName=discipline.ProfessorName
                };
                view.Disciplines.Add(d);
            }

            return this.View(view);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscipline(Discipline discipline)
        {
            var name = discipline.Name;
            var professorName = discipline.ProfessorName;
            await this.disciplineService.CreateDisciplineAsync(name, professorName);

            return this.RedirectToAction(nameof(DisciplinesList));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDiscipline(Discipline discipline)
        {
            //if (await this.disciplineService.DisciplineExistAsync(discipline.Id))
            //{
            //    return this.NotFound();
            //}

            if (this.ModelState.IsValid)
            {
                try
                {
                    await this.disciplineService.UpdateDisciplineAsync(discipline);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
                
            return this.RedirectToAction(nameof(DisciplinesList));
        }
    }
}
