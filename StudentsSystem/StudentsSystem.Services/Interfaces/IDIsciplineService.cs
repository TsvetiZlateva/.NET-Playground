using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Services.Interfaces
{
    public interface IDIsciplineService
    {
        Task<ICollection<Discipline>> GetAllDisciplinesAsync();
        System.Threading.Tasks.Task CreateDisciplineAsync(string name, string professorName);
        System.Threading.Tasks.Task UpdateDisciplineAsync(Discipline discipline);
        System.Threading.Tasks.Task DeleteDisciplineAsync(int id);
        System.Threading.Tasks.Task<bool> DisciplineExistAsync(int id);
    }
}
