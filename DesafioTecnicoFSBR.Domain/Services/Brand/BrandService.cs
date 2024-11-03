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

        public async Task<Entities.Brand> Update
        (
            Guid id,
            string name,
            CancellationToken cancellationToken
        )
        {
            await ValidateExistence(name: name, cancellationToken: cancellationToken);
            var brand = await GetBrand(id: id, cancellationToken: cancellationToken);

            brand.Update(name: name);

            return brand;
        }

        public async Task Delete
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var brand = await GetBrand(id: id, cancellationToken: cancellationToken);
            _brandRepository.Delete(brand);
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

        private async Task<Entities.Brand> GetBrand
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var brand = await _brandRepository.Get(id: id, tracking: true, cancellationToken: cancellationToken)
                        ?? throw new DomainException($"Marca de ID: {id} não encontrada.");

            return brand;
        }
    }
}
