﻿using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using Entities = DesafioTecnicoFSBR.Domain.Entities;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Create
{
    internal class CreateCarHandler
    (
        ICarService carService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateCarCommand, Response<CarResponse>>
    {
        private readonly ICarService _carService = carService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<CarResponse>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carService.Create
            (
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
