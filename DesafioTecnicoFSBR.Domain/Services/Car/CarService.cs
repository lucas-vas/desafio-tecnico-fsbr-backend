using DesafioTecnicoFSBR.Domain.Entities;
using DesafioTecnicoFSBR.Domain.Exceptions;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;

namespace DesafioTecnicoFSBR.Domain.Services.Car
{
    public sealed class CarService
    (
        ICarRepository carRepository,
        IBrandRepository brandRepository
    ) : ICarService
    {
        private readonly ICarRepository _carRepository = carRepository;
        private readonly IBrandRepository _brandRepository = brandRepository;

        public async Task<Entities.Car> Create
        (
            string modelDescription,
            int year,
            double value,
            Guid brandId,
            CancellationToken cancellationToken
        )
        {
            var brand = await GetBrand(brandId: brandId, cancellationToken: cancellationToken);

            await ValidateExistence(modelDescription: modelDescription, year: year, cancellationToken: cancellationToken);

            var car = Entities.Car.Create
            (
                modelDescription: modelDescription,
                year: year,
                value: value,
                brandId: brand.Id
            );

            await _carRepository.AddAsync(car, cancellationToken);

            return car;
        }

        public async Task<Entities.Car> Update
        (
            Guid id,
            string modelDescription,
            int year,
            double value,
            Guid brandId,
            CancellationToken cancellationToken
        )
        {
            var brand = await GetBrand(brandId: brandId, cancellationToken: cancellationToken);

            await ValidateExistence(modelDescription: modelDescription, year: year, cancellationToken: cancellationToken);

            var car = await GetCar(id: id, cancellationToken: cancellationToken);

            car.Update
            (
                modelDescription: modelDescription,
                year: year,
                value: value,
                brandId: brand.Id
            );

            return car;
        }

        public async Task Delete
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var car = await GetCar(id: id, cancellationToken: cancellationToken);
            _carRepository.Delete(car);
        }

        private async Task ValidateExistence
        (
            string modelDescription,
            int year,
            CancellationToken cancellationToken
        )
        {
            bool existCarRegistered = await _carRepository.Exist
            (
                car => car.ModelDescription.ToUpper().Equals(modelDescription.ToUpper()) &&
                car.Year == year,
                cancellationToken: cancellationToken
            );

            DomainException.When(existCarRegistered, "Já existe cadastro de um carro com esta descrição de modelo e do mesmo ano");
        }

        private async Task<Entities.Brand> GetBrand
        (
            Guid brandId,
            CancellationToken cancellationToken
        )
        {
            var brand = await _brandRepository.Get(id: brandId, cancellationToken: cancellationToken)
                        ?? throw new DomainException($"Marca de ID: {brandId} não encontrada.");

            return brand;
        }

        private async Task<Entities.Car> GetCar
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var car = await _carRepository.Get(id: id, tracking: true, cancellationToken: cancellationToken)
                      ?? throw new DomainException($"Não foi encontrado um carro com o id: {id}");

            return car;
        }
    }
}
