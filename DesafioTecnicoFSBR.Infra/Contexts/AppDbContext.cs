using DesafioTecnicoFSBR.Domain.Abstraction;
using DesafioTecnicoFSBR.Domain.Entities;
using DesafioTecnicoFSBR.Identity.Models;
using DesafioTecnicoFSBR.Infra.Configuration.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioTecnicoFSBR.Infra.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUser currentUser) : IdentityDbContext<User>(options)
    {
        private ICurrentUser _currentUser = currentUser;

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyConfigurationsFromAssembly(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userId = _currentUser.Get();

            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.SetCreatedBy(userId);
                        entry.Entity.SetCreatedAt();
                    break;
                    case EntityState.Modified:
                        entry.Entity.SetUpdatedBy(userId);
                        entry.Entity.SetUpdatedAt();
                    break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        private static void ApplyConfigurationsFromAssembly(ModelBuilder modelBuilder)
        {
            var mappingTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces()
                    .Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var mappingType in mappingTypes)
            {
                dynamic mappingInstance = Activator.CreateInstance(mappingType);
                modelBuilder.ApplyConfiguration(mappingInstance);
            }
        }

    }
}
