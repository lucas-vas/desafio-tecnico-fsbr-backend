using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAll
{
    internal class GetAllCarsHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<GetAllCarsQuery, IEnumerable<CarResponse>>
    {
        private readonly ICarRepository _carRepository = carRepository;

        public async Task<IEnumerable<CarResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.Get(include: query => query.Include(car => car.Brand), cancellationToken: cancellationToken);
            var carsResponse = cars.Select(car => CarResponse.MapFromTheEntity(car));

            return carsResponse;
        }
    }
}
