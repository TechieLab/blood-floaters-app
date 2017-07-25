using BloodFloater.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BloodFloater.DAL
{
    public class BloodFloaterContext : DbContext
    {
        public BloodFloaterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Donor> Donors { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<Lookup> Lookups { get; set; }

        public DbSet<Media> Photos { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Receiver> Receivers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            // Album
            modelBuilder.Entity<Address>().Property(a => a.AddressLine1).HasMaxLength(100);
            modelBuilder.Entity<Address>().Property(a => a.AddressLine2).HasMaxLength(500);
            modelBuilder.Entity<Address>().Property(a => a.Street).HasMaxLength(100);
            modelBuilder.Entity<Address>().Property(a => a.City).HasMaxLength(500);
            modelBuilder.Entity<Address>().Property(a => a.Landmark).HasMaxLength(100);
            modelBuilder.Entity<Address>().Property(a => a.IsOfficeAddress).HasMaxLength(500);
            modelBuilder.Entity<Address>().Property(a => a.IsPermanetAddress).HasMaxLength(100);
            modelBuilder.Entity<Address>().Property(a => a.IsHomeAddress).HasMaxLength(100);
            modelBuilder.Entity<Address>().HasOne(a => a.Profile);

            modelBuilder.Entity<Contact>().Property(a => a.PhoneNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Contact>().Property(a => a.LandLineNumber).HasMaxLength(12);
            modelBuilder.Entity<Contact>().Property(a => a.AltEmailId).HasMaxLength(100);
            modelBuilder.Entity<Contact>().Property(a => a.EmailId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Contact>().Property(a => a.AltPhoneNumber).HasMaxLength(12);
            modelBuilder.Entity<Contact>().HasOne(a => a.Profile);

            modelBuilder.Entity<Donation>().HasOne(a => a.DonatedAt);
            modelBuilder.Entity<Donation>().Property(a => a.DontatedOn).HasMaxLength(100);
            //modelBuilder.Entity<Donation>().HasMany(a => a.Receipiant).WithOne(p => p.Reciver);
            
            modelBuilder.Entity<Donor>().HasOne(a => a.Profile);
            modelBuilder.Entity<Donor>().HasOne(a => a.Donation);
            modelBuilder.Entity<Donor>().HasMany(a => a.PastDonations);

            modelBuilder.Entity<Lookup>().Property(a => a.Key).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Lookup>().Property(a => a.Value).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Lookup>().Property(a => a.Name).HasMaxLength(100);
            modelBuilder.Entity<Lookup>().Property(a => a.Description).HasMaxLength(500);

            // Photos
            modelBuilder.Entity<Media>().Property(p => p.Title).HasMaxLength(100);

            modelBuilder.Entity<Profile>().Property(a => a.FullName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Profile>().Property(a => a.Age).HasMaxLength(100);
            modelBuilder.Entity<Profile>().Property(a => a.Gender).HasMaxLength(100);
            modelBuilder.Entity<Profile>().Property(a => a.DoB).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Profile>().HasOne(a => a.Contact).WithOne(a=>a.Profile);
            modelBuilder.Entity<Profile>().HasOne(a => a.Address).WithOne(a=>a.Profile);
            modelBuilder.Entity<Profile>().HasMany(a => a.Photos);
            modelBuilder.Entity<Profile>().HasOne(a => a.User);

            // User
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired().HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.EmailId).IsRequired().HasMaxLength(200).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.HashedPassword).IsRequired().HasMaxLength(200).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.RememberMe).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Timeout).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.PageSize).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.PhoneNumber).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Salt).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.IsLocked).HasMaxLength(200);

            // UserRole
            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).IsRequired();

            // Role
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(50);
        }
    }
}
