using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAll
{
    internal class GetAllCarsHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<GetAllCarsQuery, Response<IEnumerable<CarResponse>>>
    {
        private readonly ICarRepository _carRepository = carRepository;

        public async Task<Response<IEnumerable<CarResponse>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.Get(include: query => query.Include(car => car.Brand), cancellationToken: cancellationToken);
            var carsResponse = cars.Select(CarResponse.MapFromTheEntity);

            return Response<IEnumerable<CarResponse>>.Success(carsResponse);
        }
    }
}
