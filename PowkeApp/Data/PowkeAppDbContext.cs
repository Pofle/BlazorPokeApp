using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowkeApp.Models;

namespace PowkeApp.Data
{
    public class PowkeAppDbContext : DbContext
    {
        public PowkeAppDbContext (DbContextOptions<PowkeAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<PowkeApp.Models.Pokemon> Pokemon { get; set; } = default!;
    }
}
