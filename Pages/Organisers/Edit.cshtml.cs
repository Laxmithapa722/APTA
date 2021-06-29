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

namespace APTA.Pages.Organisers
{
    public class EditModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public EditModel(APTA.Data.ConferenceContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Organiser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganiserExists(Organiser.OrganiserID))
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

        private bool OrganiserExists(int id)
        {
            return _context.Organiser.Any(e => e.OrganiserID == id);
        }
    }
}
