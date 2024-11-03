using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Update
{
    internal sealed class UpdateBrandHandler
    (
        IBrandService brandService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateBrandCommand, Response<BrandResponse>>
    {
        private readonly IBrandService _brandService = brandService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<BrandResponse>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandService.Update(id: request.Id, name: request.Name, cancellationToken: cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            var brandResponse = BrandResponse.MapFromTheEntity(brand);

            return Response<BrandResponse>.Success(brandResponse);
        }
    }
}
