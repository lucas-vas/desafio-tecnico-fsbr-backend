using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Update
{
    public sealed record UpdateBrandCommand : IRequest<Response<BrandResponse>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
