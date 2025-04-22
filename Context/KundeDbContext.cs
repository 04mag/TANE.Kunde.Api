using Microsoft.EntityFrameworkCore;
using TANE.Kunde.Api.Model;

namespace TANE.Kunde.Api.Context
{
    public class KundeDbContext : DbContext
    {
        public KundeDbContext(DbContextOptions<KundeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KundeModel>().ToTable("Kunde");

        }

        public DbSet<KundeModel> Kunder { get; set; } = null!;
    }
}
