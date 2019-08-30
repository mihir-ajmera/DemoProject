using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.DTO
{
    public class CountryDto
    {
        public int Id { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country name must be entered")]
        public string CountryName { get; set; }
    }
}