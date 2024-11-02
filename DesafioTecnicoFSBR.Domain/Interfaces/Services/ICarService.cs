namespace DesafioTecnicoFSBR.Domain.Interfaces.Services
{
    public interface ICarService
    {
        Task<Entities.Car> Create
        (
            string modelDescription,
            int year,
            double value,
            Guid brandId,
            CancellationToken cancellationToken
        );

        Task<Entities.Car> Update
        (
            Guid id,
            string modelDescription,
            int year,
            double value,
            Guid brandId,
            CancellationToken cancellationToken
        );

        Task Delete
        (
            Guid id,
            CancellationToken cancellationToken
        );
    }
}
