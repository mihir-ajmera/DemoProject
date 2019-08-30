using DemoProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Confirm password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Please enter Postal code/Pin")]
        [MinLength(7), MaxLength(7)]
        public int PostalCode { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Facebook URL")]
        public string Facebook { get; set; }

        [Display(Name = "Twitter URL")]
        public string Twitter { get; set; }

        [Display(Name = "LinkedIn URL")]
        public string LinkedIn { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [MinLength(1), MaxLength(10)]
        [RegularExpression("^[0-9]*$")]
        public int Contact { get; set; }

        [Display(Name = "Alternate Contact")]
        public int AlternateContact { get; set; }

        [Display(Name = "Gender")]
        public Gender gender { get; set; }

        [Display(Name = "Qualification")]
        public Qualification qualification { get; set; }
        public string Avatar { get; set; }

        [Display(Name = "Country")]
        public int CountryID { get; set; }

        [Display(Name = "State")]
        public int StateID { get; set; }

        [Display(Name = "City")]
        public int CityID { get; set; }

    }
}