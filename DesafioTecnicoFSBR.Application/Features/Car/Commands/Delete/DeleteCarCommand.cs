using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Delete
{
    public sealed record DeleteCarCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
