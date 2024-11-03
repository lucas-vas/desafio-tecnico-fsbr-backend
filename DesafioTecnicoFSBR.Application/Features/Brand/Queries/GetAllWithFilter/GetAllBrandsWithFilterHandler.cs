using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Filters.Brand;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Queries.GetAllWithFilter
{
    internal sealed class GetAllBrandsWithFilterHandler
    (
        IBrandRepository brandRepository
    ) : IRequestHandler<GetAllBrandsWithFilterQuery, Response<IEnumerable<BrandResponse>>>
    {
        private readonly IBrandRepository _brandRepository = brandRepository;

        public async Task<Response<IEnumerable<BrandResponse>>> Handle(GetAllBrandsWithFilterQuery request, CancellationToken cancellationToken)
        {
            var filter = BrandFilter.Get(name: request.Name);

            var brands = await _brandRepository.Get(condition: filter, cancellationToken: cancellationToken);
            var brandsResponse = brands.Select(BrandResponse.MapFromTheEntity);

            return Response<IEnumerable<BrandResponse>>.Success(brandsResponse);
        }
    }
}
