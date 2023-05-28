using IssaWPF6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssaWPF6.DAL
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ReportsV2;User Id=postgres;Password=postgres;Timeout=300;");
        }


        public DbSet<Colon> Colons { get; set; }
        public DbSet<Stomach> Stomaches { get; set; }
    }
}
