using DesafioTecnicoFSBR.Domain.Entities;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using DesafioTecnicoFSBR.Infra.Contexts;

namespace DesafioTecnicoFSBR.Infra.Persistence.Repositories
{
    internal sealed class CarRepository(AppDbContext context) : Repository<Car>(context), ICarRepository
    {
    }
}
