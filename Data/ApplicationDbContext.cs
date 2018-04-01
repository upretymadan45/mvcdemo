using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcdemo.Models;

namespace mvcdemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationApplicationUser> UserNotifications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                    .HasMany(p=>p.Pets)
                    .WithOne(u=>u.User)
                    .IsRequired();

            builder.Entity<Pet>()
                    .HasMany(w=>w.Watchlists)
                    .WithOne(p=>p.Pet)
                    .IsRequired();

            builder.Entity<ApplicationUser>()
                    .HasMany(w=>w.Watchlists)
                    .WithOne(u=>u.User)
                    .IsRequired();

            builder.Entity<NotificationApplicationUser>()
                    .HasKey(k=>new{k.NotificationId,k.ApplicationUserId});

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
