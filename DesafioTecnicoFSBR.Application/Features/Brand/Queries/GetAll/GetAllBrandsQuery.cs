using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Queries.GetAll
{
    public sealed record GetAllBrandsQuery : IRequest<Response<IEnumerable<BrandResponse>>>
    {
    }
}
