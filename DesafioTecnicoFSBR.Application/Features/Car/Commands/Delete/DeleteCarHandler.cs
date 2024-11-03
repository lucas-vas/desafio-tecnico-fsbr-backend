using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Delete
{
    internal sealed class DeleteCarHandler
    (
        ICarService carService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteCarCommand, Response<string>>
    {
        private readonly ICarService _carService = carService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<string>> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.Delete(id: request.Id, cancellationToken: cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Response<string>.Success($"Carro de ID: {request.Id} deletado com sucesso");
        }
    }
}
