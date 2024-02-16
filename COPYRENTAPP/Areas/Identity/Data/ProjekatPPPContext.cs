using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjekatPPP.Models.Entity;

namespace ProjekatPPP.Data;

public class ProjekatPPPContext : IdentityDbContext<IdentityUser>
{
    private readonly DbContextOptions _options;

    public ProjekatPPPContext(DbContextOptions<ProjekatPPPContext> options)
        : base(options)
    {
        _options = options;
    }

    public DbSet<Masina> Masine { get; set; }
    public DbSet<Kupac> Kupac { get; set; }
    public DbSet<Faktura> Faktura { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
