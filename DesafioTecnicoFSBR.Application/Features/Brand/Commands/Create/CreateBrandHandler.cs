﻿using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Create
{
    public sealed class CreateBrandHandler
    (
        IBrandService brandService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateBrandCommand, Response<BrandResponse>>
    {
        private readonly IBrandService _brandService = brandService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<BrandResponse>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandService.Create(name: request.Name, cancellationToken: cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
            var brandResponse = BrandResponse.MapFromTheEntity(brand);

            return Response<BrandResponse>.Success(brandResponse);
        }
    }
}
