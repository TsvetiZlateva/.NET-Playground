using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Data.Models
{
    public class Semester
    {
        public Semester()
        {
            this.Disciplines = new HashSet<Discipline>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
