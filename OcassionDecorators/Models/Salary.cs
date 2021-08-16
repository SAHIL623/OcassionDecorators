using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OcassionDecorators.Models
{
    public class Salary
    {

        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }

      


        [Display(Name = "Salary")]
        public string ESalary { get; set; }


        [Display(Name = "Date ")]
        public DateTime dTime { get; set; }
    }
}
