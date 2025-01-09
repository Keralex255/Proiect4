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
    public class DeleteModel : PageModel
    {
        private readonly Proiect4.Data.Proiect4Context _context;

        public DeleteModel(Proiect4.Data.Proiect4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Treatment Treatment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.FirstOrDefaultAsync(m => m.TreatmentId == id);

            if (treatment == null)
            {
                return NotFound();
            }
            else
            {
                Treatment = treatment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.FindAsync(id);
            if (treatment != null)
            {
                Treatment = treatment;
                _context.Treatment.Remove(Treatment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
