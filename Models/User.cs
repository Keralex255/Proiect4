using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Proiect4.Models
{
    public class User : IdentityUser<int>  // Păstrăm UserId de tip int
    {
        public string Name { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
