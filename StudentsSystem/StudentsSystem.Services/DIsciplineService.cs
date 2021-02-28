using StudentsSystem.Data;
using StudentsSystem.Data.Models;
using StudentsSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Services
{
    public class DIsciplineService : IDIsciplineService
    {
        private readonly MySqlDatabase db;

        public DIsciplineService(MySqlDatabase db)
        {
            this.db = db;
        }

        public async System.Threading.Tasks.Task CreateDisciplineAsync(string name, string professorName)
        {
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"INSERT INTO `student_system`.`disciplines`(`Name`,`ProfessorName`)VALUES('{0}','{1}');", name, professorName);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<ICollection<Discipline>> GetAllDisciplinesAsync()
        {
            List<Discipline> list = new List<Discipline>();
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM student_system.disciplines;";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var discipline = new Discipline()
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1),
                        ProfessorName = reader.GetFieldValue<string>(2)
                    };
                   
                    list.Add(discipline);
                }

            return list;
        }
    }
}
