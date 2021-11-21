using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Data.Model.Localization;
using Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Data;

public class AppDBContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserClaim<string>,
    AppUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Culture> Cultures { get; set; }
    public DbSet<LocalizationSet> LocalizationSets { get; set; }
    public DbSet<Localization> Localizations { get; set; }

    public DbSet<AppImage> Images { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<KeyValueHelper> KeyValueHelpers { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Message> Messages { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
        builder.Entity<Culture>(etb =>
        {
            etb.HasKey(e => e.Code);
            etb.Property(e => e.Name).IsRequired().HasMaxLength(64);
        });

        builder.Entity<Localization>(etb =>
        {
            etb.HasKey(e => new { e.LocalizationSetId, e.CultureCode });
        });

        builder.Entity<LocalizationSet>(etb =>
        {
            etb.HasMany(e => e.Localizations)
                .WithOne(e => e.LocalizationSet)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<AppUserRole>(userRole =>
        {
            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });
    }
}

