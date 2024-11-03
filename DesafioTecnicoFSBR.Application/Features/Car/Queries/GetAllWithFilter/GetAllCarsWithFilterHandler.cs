using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Application.Utils.Filters.Car;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAllWithFilter
{
    internal sealed class GetAllCarsWithFilterHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<GetAllCarsWithFilterQuery, Response<IEnumerable<CarResponse>>>
    {
        private readonly ICarRepository _carRepository = carRepository;

        public async Task<Response<IEnumerable<CarResponse>>> Handle(GetAllCarsWithFilterQuery request, CancellationToken cancellationToken)
        {
            var filter = CarFilter.Get
            (
                modelDescription: request.ModelDescription,
                year: request.Year,
                brandId: request.BrandId
            );

            var cars = await _carRepository.Get(condition: filter, include: query => query.Include(car => car.Brand), cancellationToken: cancellationToken);
            var carsResponse = cars.Select(CarResponse.MapFromTheEntity);

            return Response<IEnumerable<CarResponse>>.Success(carsResponse);
        }
    }
}
