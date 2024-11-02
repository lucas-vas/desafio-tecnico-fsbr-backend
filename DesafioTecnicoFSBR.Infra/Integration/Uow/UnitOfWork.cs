using DesafioTecnicoFSBR.Infra.Contexts;

namespace DesafioTecnicoFSBR.Infra.Integration.Uow
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
