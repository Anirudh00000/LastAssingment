using ClassLibraryForunversity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForunversity.unversitycontext
{
    public class UnversityDbContext:DbContext
    {
 
        public DbSet<University> Universitys { get; set; }
        public UnversityDbContext()
        {

        }
        public UnversityDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-71Q79TQ;Initial Catalog=UnversitydataAssingment;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<University>(entity => entity.HasIndex(e => e.UniversityName).IsUnique());
        }
    }



}

