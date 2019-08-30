using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.DTO
{
    public class StateDto
    {
        public int Id { get; set; }

        [Display(Name = "State")]
        [StringLength(100)]
        [Required(ErrorMessage = "State name must be entered")]
        public string StateName { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country must be selected")]
        public int CountryId { get; set; }
        
        //[ForeignKey("CountryId")]
        //public CountryDto Country { get; set; }
    }
}