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
    public class IndexModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public IndexModel(APTA.Data.ConferenceContext context)
        {
            _context = context;
        }

        public IList<Conference> Conference { get;set; }

        public async Task OnGetAsync()
        {
            Conference = await _context.Conference
                .Include(c => c.Organiser).ToListAsync();
        }
        
    }
}
