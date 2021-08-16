using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcassionDecorators.Models;

namespace OcassionDecorators.Data
{
    public class OcassionDecoratorsContext : DbContext
    {
        public OcassionDecoratorsContext (DbContextOptions<OcassionDecoratorsContext> options)
            : base(options)
        {
        }

        public DbSet<OcassionDecorators.Models.login> login { get; set; }

        public DbSet<OcassionDecorators.Models.Employee> Employee { get; set; }

        public DbSet<OcassionDecorators.Models.Salary> Salary { get; set; }

        public DbSet<OcassionDecorators.Models.Booking> Booking { get; set; }
    }
}
