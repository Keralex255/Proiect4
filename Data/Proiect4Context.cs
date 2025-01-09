using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect4.Models;

namespace Proiect4.Data
{
    public class Proiect4Context : DbContext
    {
        public Proiect4Context (DbContextOptions<Proiect4Context> options)
            : base(options)
        {
        }

        public DbSet<Proiect4.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<Proiect4.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<Proiect4.Models.Review> Review { get; set; } = default!;
        public DbSet<Proiect4.Models.User> User { get; set; } = default!;
        public DbSet<Proiect4.Models.Treatment> Treatment { get; set; } = default!;
    }
}
