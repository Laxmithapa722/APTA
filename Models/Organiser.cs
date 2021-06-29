using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APTA.Models
{
    public class Organiser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganiserID { get; set; }
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
        [StringLength(45, ErrorMessage = "Sponsor cannot be longer than 45 characters.")]
        [Display(Name = "Sponsor")] 
        public string Sponsor { get; set; }

        public ICollection<Conference> Conferences { get; set; }
    }
}

