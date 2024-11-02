using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Create
{
    public sealed record CreateBrandCommand : IRequest<BrandResponse>
    {
        public string Name { get; set; }
    }
}
