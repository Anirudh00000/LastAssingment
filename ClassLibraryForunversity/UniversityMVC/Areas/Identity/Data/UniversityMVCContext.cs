using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityMVC.Areas.Identity.Data;

namespace UniversityMVC.Data;

public class UniversityMVCContext : IdentityDbContext<UniversityMVCUser>
{
    public UniversityMVCContext(DbContextOptions<UniversityMVCContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<ClassLibraryForunversity.Model.University>? University { get; set; }
  

}
