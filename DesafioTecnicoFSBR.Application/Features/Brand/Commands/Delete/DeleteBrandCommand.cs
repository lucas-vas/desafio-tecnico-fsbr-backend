using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Delete
{
    public sealed record DeleteBrandCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
    }
}
