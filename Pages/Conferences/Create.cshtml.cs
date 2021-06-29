using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using APTA.Data;
using APTA.Models;

namespace APTA.Pages.Conferences
{
    public class CreateModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public CreateModel(APTA.Data.ConferenceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrganiserID"] = new SelectList(_context.Set<Organiser>(), "OrganiserID", "OrganiserID");
            return Page();
        }

        [BindProperty]
        public Conference Conference { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Conference.Add(Conference);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
