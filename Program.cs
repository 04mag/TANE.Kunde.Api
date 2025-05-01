
using Microsoft.EntityFrameworkCore;
using TANE.Kunde.Api.Context;
using TANE.Kunde.Api.REPO.Interface;
using TANE.Kunde.Api.REPO;

namespace TANE.Kunde.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔹Add DbContext med connection string
            builder.Services.AddDbContext<KundeDbContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // 🔹Create database
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<KundeDbContext>();

                try
                {
                    context.Database.EnsureCreated();
                }
                catch
                {
                    //Close app if database creation fails
                    Console.WriteLine("Database creation failed");
                    Environment.Exit(1);
                }
            }

            // 🔹Add REPO
            builder.Services.AddScoped<IKundeREPO, KundeREPO>();


            // 🔹Add services to the container.
            builder.Services.AddControllers();
            // 🔹Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 🔹Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
