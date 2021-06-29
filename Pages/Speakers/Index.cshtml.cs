using System;
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
    public class IndexModel : PageModel
    {
        private readonly APTA.Data.ConferenceContext _context;

        public IndexModel(APTA.Data.ConferenceContext context)
        {
            _context = context;
        }

        public IList<Speaker> Speaker { get;set; }

        public async Task OnGetAsync()
        {
            Speaker = await _context.Speaker
                .Include(s => s.Conference).ToListAsync();
        }
    }
}
