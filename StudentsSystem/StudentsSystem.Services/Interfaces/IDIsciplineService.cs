using StudentsSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsSystem.Services.Interfaces
{
    public interface IDisciplineService
    {
        Task<ICollection<Discipline>> GetAllDisciplinesAsync();
        Task CreateDisciplineAsync(string name, string professorName, int? semesterId = null);
        Task UpdateDisciplineAsync(Discipline discipline);
        Task DeleteDisciplineAsync(int id);
        Task<bool> DisciplineExistAsync(int id);
    }
}
