using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect4.Data;
using Proiect4.Models;

namespace Proiect4.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly Proiect4.Data.Proiect4Context _context;

        public IndexModel(Proiect4.Data.Proiect4Context context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Review = await _context.Review
                .Include(r => r.Doctor)
                .Include(r => r.User).ToListAsync();
        }
    }
}
