using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WorkExperience
    {
        [Key]
        public int Id { get; set; }
      
        public string Company { get; set; }
      
        public DateTime WorkingFrom { get; set; }
      
        public DateTime WorkingTo { get; set; }
        [ForeignKey("WorkExperienceId")]
        public List<Role> Roles { get; set; }
    }
}
