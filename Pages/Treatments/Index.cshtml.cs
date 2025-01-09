using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect4.Data;
using Proiect4.Models;

namespace Proiect4.Pages.Treatments
{
    public class IndexModel : PageModel
    {
        private readonly Proiect4.Data.Proiect4Context _context;

        public IndexModel(Proiect4.Data.Proiect4Context context)
        {
            _context = context;
        }

        public IList<Treatment> Treatment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Treatment = await _context.Treatment.ToListAsync();
        }
    }
}
