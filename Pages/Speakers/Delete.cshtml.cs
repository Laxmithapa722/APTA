﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APTA.Data;
using APTA.Models;

namespace APTA.Pages.Speakers
{
    public class DeleteModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public DeleteModel(APTA.Data.ConferenceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Speaker Speaker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Speaker = await _context.Speaker
                .Include(s => s.Conference).FirstOrDefaultAsync(m => m.SpeakerID == id);

            if (Speaker == null)
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

            Speaker = await _context.Speaker.FindAsync(id);

            if (Speaker != null)
            {
                _context.Speaker.Remove(Speaker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
