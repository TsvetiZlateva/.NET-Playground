using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsSystem.Web.Model
{
    public class DisciplinesListViewModel
    {
        public DisciplinesListViewModel()
        {
            this.Disciplines = new List<Discipline>();
        }

        public Discipline Discipline { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}
