namespace DesafioTecnicoFSBR.Domain.Interfaces.Services
{
    public interface IBrandService
    {
        Task<Entities.Brand> Create
        (
            string name,
            CancellationToken cancellationToken
        );

        Task<Entities.Brand> Update
        (
            Guid id,
            string name,
            CancellationToken cancellationToken
        );

        Task Delete
        (
            Guid id,
            CancellationToken cancellationToken
        );
    }
}
