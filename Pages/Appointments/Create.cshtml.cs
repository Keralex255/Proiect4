using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect4.Data;
using Proiect4.Models;

namespace Proiect4.Pages.Appointments
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
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "DoctorId", "Name");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Name");

            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
