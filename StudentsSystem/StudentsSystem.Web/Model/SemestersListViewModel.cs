using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsSystem.Web.Model
{
    public class SemestersListViewModel
    {
        public SemestersListViewModel()
        {
            this.Semesters = new List<Semester>();
        }

        public Semester Semester { get; set; }
        public List<Semester> Semesters { get; set; }
    }
}
