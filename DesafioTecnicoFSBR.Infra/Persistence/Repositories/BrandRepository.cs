using DesafioTecnicoFSBR.Domain.Entities;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using DesafioTecnicoFSBR.Infra.Contexts;

namespace DesafioTecnicoFSBR.Infra.Persistence.Repositories
{
    internal sealed class BrandRepository(AppDbContext context) : Repository<Brand>(context), IBrandRepository
    {
    }
}
