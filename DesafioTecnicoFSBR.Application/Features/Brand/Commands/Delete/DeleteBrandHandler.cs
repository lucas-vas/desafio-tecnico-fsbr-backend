using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Delete
{
    internal sealed class DeleteBrandHandler
    (
        IBrandService brandService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteBrandCommand, Response<string>>
    {
        private readonly IBrandService _brandService = brandService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<string>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandService.Delete(id: request.Id, cancellationToken: cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Response<string>.Success($"Marca de ID: {request.Id} deletada com sucesso");
        }
    }
}
