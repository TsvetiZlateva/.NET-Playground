using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Services.Interfaces
{
    public interface ISemesterService
    {
        Task<ICollection<Semester>> GetAllSemestersAsync();
        Task CreateSemesterAsync(string name, DateTime startDate, DateTime endDate);

        Task UpdateSemesterAsync(Semester semester);
    }
}
