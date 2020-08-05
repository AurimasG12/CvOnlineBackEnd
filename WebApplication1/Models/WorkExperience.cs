using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WorkExperience
    {
        [Key]
        public int Id { get; set; }
        public string Company { get; set; }
        public int WorkingFrom { get; set; }
        public int WorkingTo { get; set; }
        public Role[] Roles { get; set; }
    }
}
