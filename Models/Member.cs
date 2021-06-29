using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APTA.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "First name cannot be longer than 25 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Last name cannot be longer than 25 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public int Phone { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Email cannot be longer than 45 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Address cannot be longer than 45 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        

        public ICollection<Registration> Registrations { get; set; }


    }
}
