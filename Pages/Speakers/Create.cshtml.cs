using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using APTA.Data;
using APTA.Models;

namespace APTA.Pages.Speakers
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
        ViewData["ConferenceID"] = new SelectList(_context.Conference, "ConferenceID", "ConferenceID");
            return Page();
        }

        [BindProperty]
        public Speaker Speaker { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Speaker.Add(Speaker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
