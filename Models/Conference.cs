using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APTA.Models
{
    public class Conference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConferenceID { get; set; }
        [Required]
        [StringLength(45, ErrorMessage = "Title cannot be longer than 45 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Location cannot be longer than 45 characters.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "OrganiserID")]
        public int OrganiserID { get; set; }
        public Organiser Organiser { get; set; }

        public ICollection<Speaker> Speakers { get; set; }
        public ICollection<Registration> Registrations { get; set; }

    }
}
