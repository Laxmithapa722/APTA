using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APTA.Data;
using APTA.Models;

namespace APTA.Pages.Conferences
{
    public class EditModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public EditModel(APTA.Data.ConferenceContext context)
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
           ViewData["OrganiserID"] = new SelectList(_context.Set<Organiser>(), "OrganiserID", "OrganiserID");
            return Page();
        }
        

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Conference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenceExists(Conference.ConferenceID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConferenceExists(int id)
        {
            return _context.Conference.Any(e => e.ConferenceID == id);
        }
    }
}
