using DesafioTecnicoFSBR.Domain.Exceptions;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;

namespace DesafioTecnicoFSBR.Domain.Services.Brand
{
    public sealed class BrandService
    (
        IBrandRepository brandRepository
    ) : IBrandService
    {
        private readonly IBrandRepository _brandRepository = brandRepository;

        public async Task<Entities.Brand> Create
        (
            string name,
            CancellationToken cancellationToken
        )
        {
            await ValidateExistence(name: name, cancellationToken: cancellationToken);

            var brand = Entities.Brand.Create(name: name);
            await _brandRepository.AddAsync(brand, cancellationToken);

            return brand;
        }

        private async Task ValidateExistence
        (
            string name,
            CancellationToken cancellationToken
        )
        {
            bool existCarRegistered = await _brandRepository.Exist
            (
                brand => brand.Name.ToUpper().Equals(name.ToUpper()),
                cancellationToken: cancellationToken
            );

            DomainException.When(existCarRegistered, "Já existe cadastro de uma marca com este nome");
        }
    }
}
