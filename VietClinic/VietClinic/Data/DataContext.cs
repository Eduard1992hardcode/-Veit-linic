using Microsoft.EntityFrameworkCore;

namespace VietClinic.Models
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>(o =>
            {
                o.HasMany(o => o.Pets)
                .WithOne()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Pet>().Property(p => p.Name).HasMaxLength(20);
        }
    }
}
