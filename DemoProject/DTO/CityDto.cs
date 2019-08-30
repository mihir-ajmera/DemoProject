using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.DTO
{
    public class CityDto
    {
        public int Id { get; set; }

        [Display(Name = "City")]
        [StringLength(100)]
        [Required(ErrorMessage = "City name must be entered")]
        public string CityName { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State must be selected")]
        public int StateID { get; set; }
        //[ForeignKey("StateID")]
        //public State State { get; set; }
    }
}