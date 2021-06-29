using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APTA.Data;
using APTA.Models;

namespace APTA.Pages.Organisers
{
    public class DetailsModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public DetailsModel(APTA.Data.ConferenceContext context)
        {
            _context = context;
        }

        public Organiser Organiser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Organiser = await _context.Organiser.FirstOrDefaultAsync(m => m.OrganiserID == id);

            if (Organiser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
