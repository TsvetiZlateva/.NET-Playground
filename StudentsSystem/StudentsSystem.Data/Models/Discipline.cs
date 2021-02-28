using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Data.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [MaxLength(45)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Just letters and space are allowed.")]
        [DisplayName("Professor Name")]
        public string ProfessorName { get; set; }

        public int? SemesterID { get; set; }

        public virtual Semester Semester { get; set; }
    }
}
