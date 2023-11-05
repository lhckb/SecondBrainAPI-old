using Microsoft.EntityFrameworkCore;
using SecondBrainAPI.Repositories;
using SecondBrainAPI.Routes;

namespace SecondBrainAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SecondBrainDb>(opt =>
            {
                // opt.UseInMemoryDatabase("SecondBrain");

                // TODO: transfer to app secrets
                opt.UseNpgsql("Host=localhost;Port=5433;Database=SecondBrain;Username=postgres;Password=password", builder =>
                {
                    builder.MigrationsAssembly("SecondBrainAPI");
                });
            });

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var app = builder.Build();

            UserRouter.Map(app);
            ReminderRouter.Map(app);

            app.Run();
        }
    }
}