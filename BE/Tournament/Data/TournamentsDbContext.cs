using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tournament.Api.Data
{
    public class TournamentsDbContext : IdentityDbContext
    {
        public TournamentsDbContext(DbContextOptions<TournamentsDbContext> options)
        : base(options)
        {
        }

        public DbSet<Models.Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Tournament>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Tournaments");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Organizer)
                    .HasColumnType("varchar(256)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
