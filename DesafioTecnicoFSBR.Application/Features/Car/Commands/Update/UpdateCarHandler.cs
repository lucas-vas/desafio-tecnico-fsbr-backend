using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Update
{
    internal sealed class UpdateCarHandler
    (
        ICarService carService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateCarCommand, Response<CarResponse>>
    {
        private readonly ICarService _carService = carService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<CarResponse>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carService.Update
            (
                id: request.Id,
                modelDescription: request.ModelDescription,
                year: request.Year,
                value: request.Value,
                brandId: request.BrandId,
                cancellationToken: cancellationToken
            );

            await _unitOfWork.CommitAsync(cancellationToken);
            var carResponse = CarResponse.MapFromTheEntity(car);

            return Response<CarResponse>.Success(carResponse);
        }
    }
}
