using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OcassionDecorators.Models
{
    public class Booking
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Email { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }


        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Booking Date")]
        public DateTime Dtime { get; set; }

        public Employee emp { get; set; }


    }
}
