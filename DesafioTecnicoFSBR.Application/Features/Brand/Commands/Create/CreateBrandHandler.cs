using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using Entities = DesafioTecnicoFSBR.Domain.Entities;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;
using System.Security.Claims;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Create
{
    public sealed class CreateBrandHandler
    (
        IBrandService brandService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateBrandCommand, BrandResponse>
    {
        private readonly IBrandService _brandService = brandService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandService.Create(name: request.Name, cancellationToken: cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            var brandResponse = MapBrandResponse(brand);

            return brandResponse;
        }

        private BrandResponse MapBrandResponse(Entities.Brand brand)
        {
            var brandResponse = new BrandResponse
            {
                Id = brand.Id,
                Name = brand.Name,
            };

            return brandResponse;
        }
    }
}
