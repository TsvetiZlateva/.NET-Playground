using StudentsSystem.Data;
using StudentsSystem.Data.Models;
using StudentsSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsSystem.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly MySqlDatabase db;

        public DisciplineService(MySqlDatabase db)
        {
            this.db = db;
        }

        public async Task CreateDisciplineAsync(string name, string professorName, int? semesterId = null)
        {
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"INSERT INTO `student_system`.`disciplines`(`Name`,`ProfessorName`,`SemesterId`)VALUES('{0}','{1}', {2});", name, professorName, semesterId);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteDisciplineAsync(int id)
        {
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"DELETE FROM `student_system`.`disciplines`WHERE Id = {0};", id);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<bool> DisciplineExistAsync(int id)
        {
            List<Discipline> list = new List<Discipline>();
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"SELECT * FROM student_system.disciplines where Id = {0};", id);
            var reader = await cmd.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }

            reader.Close();
            return false;          
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
                        ProfessorName = reader.GetFieldValue<string>(2),
                        SemesterID = Convert.IsDBNull(reader["SemesterId"]) ? null : (int?)reader["SemesterId"]
                    };
                   
                    list.Add(discipline);
                }

            return list;
        }

        public async Task UpdateDisciplineAsync(Discipline discipline)
        {
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = String.Format(@"UPDATE `student_system`.`disciplines` SET Name = '{0}', ProfessorName = '{1}', SemesterId = {2} WHERE Id = {3};", discipline.Name, discipline.ProfessorName, discipline.SemesterID, discipline.Id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
