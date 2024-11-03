namespace DesafioTecnicoFSBR.Infra.Integration.Uow
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Commit();
    }
}
