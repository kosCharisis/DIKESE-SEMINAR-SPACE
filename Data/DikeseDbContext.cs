using DIKESE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DIKESE.Data
{
    public class DikeseDbContext : IdentityDbContext<ApplicationUser>
    {
        public DikeseDbContext(DbContextOptions<DikeseDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker_Seminar>().HasKey(am => new
            {
                am.SpeakerId,
                am.SeminarId
            });

            modelBuilder.Entity<Speaker_Seminar>().HasOne(m => m.Seminar).WithMany(am => am.Speakers_Seminars).HasForeignKey(m => m.SeminarId);
            modelBuilder.Entity<Speaker_Seminar>().HasOne(m => m.Speaker).WithMany(am => am.Speakers_Seminars).HasForeignKey(m => m.SpeakerId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Speaker_Seminar> Speakers_Seminars { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
