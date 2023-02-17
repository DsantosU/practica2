using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Triplex.Validations;

namespace Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            ImmovableOwners = Set<ImmovableOwner>();
            ImmovableProperties = Set<ImmovableProperty>();
            
        }


        public DbSet<ImmovableOwner> ImmovableOwners { get; set; }
        public DbSet<ImmovableProperty> ImmovableProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Arguments.NotNull(modelBuilder, nameof(modelBuilder));


            modelBuilder.Entity<ImmovableProperty>()
                .HasOne(io => io.ImmovableOwner)
                .WithMany(ip => ip.ImmovableProperties)
                .HasForeignKey(nameof(ImmovableProperty.ImmovableOwnerId))
            ;
        }




    }
}
