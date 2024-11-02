namespace DesafioTecnicoFSBR.Domain.Interfaces.Services
{
    public interface IBrandService
    {
        Task<Entities.Brand> Create
        (
            string name,
            CancellationToken cancellationToken
        );
    }
}
