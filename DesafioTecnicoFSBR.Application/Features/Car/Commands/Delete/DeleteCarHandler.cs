using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Delete
{
    internal sealed class DeleteCarHandler
    (
        ICarService carService,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteCarCommand>
    {
        private readonly ICarService _carService = carService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.Delete(id: request.Id, cancellationToken: cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
