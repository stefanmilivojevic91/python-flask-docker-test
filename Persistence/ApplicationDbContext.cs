using Domain.Entities.Common;
using Domain.Entities.PropertyAggregate;
using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext :
        DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ExternalIdentity> ExternalIdentities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Metadata> Metadatas { get; set; }

        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
