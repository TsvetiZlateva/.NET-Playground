﻿using StudentsSystem.Data;
using StudentsSystem.Data.Models;
using StudentsSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly MySqlDatabase db;
        private readonly IDisciplineService disciplineService;

        public SemesterService(MySqlDatabase db, IDisciplineService dIsciplineService)
        {
            this.db = db;
            this.disciplineService = dIsciplineService;
        }

        public async Task CreateSemesterAsync(string name, DateTime startDate, DateTime endDate)
        {
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"INSERT INTO `student_system`.`semesters`(`Name`,`StartDate`,`EndDate`)VALUES('{0}','{1}', '{2}');", name, startDate.ToString("yyy-MM-dd"), endDate.ToString("yyy-MM-dd"));
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteDisciplineAsync(int id)
        {
            //TODO: Discipline can be removed only if there are no scores linked to it.
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"UPDATE `student_system`.`disciplines` SET SemesterId = null WHERE Id = {0};",  id);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<ICollection<Semester>> GetAllSemestersAsync()
        {
            var disciplines = await this.disciplineService.GetAllDisciplinesAsync();
            List<Semester> list = new List<Semester>();
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = @"select * from semesters;";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var semester = new Semester()
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1),
                        StartDate = reader.GetFieldValue<DateTime>(2),
                        EndDate = reader.GetFieldValue<DateTime>(3),
                    };


                    foreach (var discipline in disciplines.Where(d => d.SemesterID == semester.Id))
                    {
                        semester.Disciplines.Add(new Discipline
                        {
                            Id = discipline.Id,
                            Name = discipline.Name,
                            ProfessorName = discipline.ProfessorName,
                            SemesterID = discipline.SemesterID
                        });

                    }

                    list.Add(semester);
                }

            return list;
        }

        public async Task UpdateSemesterAsync(Semester semester)
        {
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"UPDATE `student_system`.`semesters` SET Name = '{0}', StartDate = '{1}', EndDate = '{2}' WHERE Id = {3};", semester.Name, semester.StartDate.ToString("yyy-MM-dd"), semester.EndDate.ToString("yyy-MM-dd"), semester.Id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
