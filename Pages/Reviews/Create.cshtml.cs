using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect4.Data;
using Proiect4.Models;

namespace Proiect4.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly Proiect4.Data.Proiect4Context _context;

        public CreateModel(Proiect4.Data.Proiect4Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorId");
        ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
