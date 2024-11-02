using DesafioTecnicoFSBR.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoFSBR.Api.Configuration.MigrationConfiguration
{
    public static class MigrationConfiguration
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using AppDbContext appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            appDbContext.Database.EnsureCreated();
            appDbContext.Database.Migrate();
        }
    }
}
