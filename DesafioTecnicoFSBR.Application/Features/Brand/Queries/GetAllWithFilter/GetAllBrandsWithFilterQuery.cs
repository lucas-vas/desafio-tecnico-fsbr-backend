using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Queries.GetAllWithFilter
{
    public sealed record GetAllBrandsWithFilterQuery : IRequest<Response<IEnumerable<BrandResponse>>>
    {
        public string? Name { get; set; }
    }
}
