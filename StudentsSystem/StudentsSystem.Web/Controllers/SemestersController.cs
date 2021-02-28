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
    public class SemestersController : Controller
    {
        private readonly ISemesterService semesterService;

        public SemestersController(ISemesterService semesterService)
        {
            this.semesterService = semesterService;
        }

        public async Task<IActionResult> SemestersList()
        {
            var view = new SemestersListViewModel();
            var semesters = await this.semesterService.GetAllSemestersAsync();

            foreach (var semester in semesters)
            {
                Semester s = new Semester
                {
                    Id = semester.Id,
                    Name = semester.Name,
                    StartDate = semester.StartDate,
                    EndDate = semester.EndDate,
                    Disciplines = semester.Disciplines
                };
                view.Semesters.Add(s);
            }

            return this.View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSemester(Semester semester)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ValidationProblem();
            }

            var name = semester.Name;
            var startDate = semester.StartDate;
            var endDate = semester.EndDate;
            await this.semesterService.CreateSemesterAsync(name, startDate, endDate);

            return this.RedirectToAction(nameof(SemestersList));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSemester(Semester semester)
        {            
            if (!this.ModelState.IsValid)
            {
                return this.View("Error");
            }

            try
            {
                await this.semesterService.UpdateSemesterAsync(semester);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return this.RedirectToAction(nameof(SemestersList));
        }

    }
}
