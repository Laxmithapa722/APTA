using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APTA.Data;
using APTA.Models;

namespace APTA.Pages.Conferences
{
    public class DeleteModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public DeleteModel(APTA.Data.ConferenceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conference Conference { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conference = await _context.Conference
                .Include(c => c.Organiser).FirstOrDefaultAsync(m => m.ConferenceID == id);

            if (Conference == null)
            {
                return NotFound();
            }
            return Page();
        }
        

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conference = await _context.Conference.FindAsync(id);

            if (Conference != null)
            {
                _context.Conference.Remove(Conference);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
