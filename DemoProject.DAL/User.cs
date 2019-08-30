using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.DAL
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(250)]
        public string Password { get; set; }
        [StringLength(250)]
        public string ConfirmPassword { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; }

        [StringLength(250)]
        public string Facebook { get; set; }
        [StringLength(250)]
        public string Twitter { get; set; }
        [StringLength(250)]
        public string LinkedIn { get; set; }
        public int Contact { get; set; }
        public int AlternateContact { get; set; }
        public Gender gender { get; set; }
        public Qualification qualification { get; set; }
        
        public int CountryID { get; set; }
        [ForeignKey("CountryID")]
        public Country Country { get; set; }
        
        public int StateID { get; set; }
        [ForeignKey("StateID")]
        public State State { get; set; }

        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }

        //public List<Country> Countries { get; set; }
        //public List<State> States { get; set; }
        //public List<City> Cities { get; set; }

    }
}
