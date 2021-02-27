using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Data.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime Completed { get; set; }
        public DateTime Archived { get; set; }
    }
}
