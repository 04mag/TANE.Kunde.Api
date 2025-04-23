using Microsoft.EntityFrameworkCore;
using TANE.Kunde.Api.Model;

namespace TANE.Kunde.Api.Context
{
    public class KundeDbContext : DbContext
    {
        public KundeDbContext(DbContextOptions<KundeDbContext> options) : base(options) { }

        // 🔹 Konfiguration af DbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KundeModel>()
                    .ToTable("Kunde")
                    .Property(k => k.RowVersion)
                    .IsRowVersion();
        }
        public DbSet<KundeModel> Kunder { get; set; } = null!;

        // 🔹 Seed data hvilket bliver kaldt i Program.cs
        //public static void SeedData(IApplicationBuilder app)
        //{
        //    using var scope = app.ApplicationServices.CreateScope();
        //    var context = scope.ServiceProvider.GetRequiredService<KundeDbContext>();

        //    context.Database.Migrate(); // sikrer at databasen er lavet eller opdateret

        //    if (!context.Kunder.Any())
        //    {
        //        context.Kunder.Add(new KundeModel
        //        {
        //            Fornavn = "Test",
        //            Efternavn = "Testesen",
        //            Email = "Test@testen.com",
        //            TlfNummer = "12345678"

        //        });

        //        context.SaveChanges();
        //    }
        //}

    }
}
