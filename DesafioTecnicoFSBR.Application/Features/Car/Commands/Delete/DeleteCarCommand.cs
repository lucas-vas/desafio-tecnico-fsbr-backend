using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Delete
{
    public sealed record DeleteCarCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
    }
}
