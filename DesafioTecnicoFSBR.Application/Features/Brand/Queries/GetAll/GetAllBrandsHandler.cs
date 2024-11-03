using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Queries.GetAll
{
    internal sealed class GetAllBrandsHandler
    (
        IBrandRepository brandRepository
    ) : IRequestHandler<GetAllBrandsQuery, Response<IEnumerable<BrandResponse>>>
    {
        private readonly IBrandRepository _brandRepository = brandRepository;

        public async Task<Response<IEnumerable<BrandResponse>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.Get(cancellationToken: cancellationToken);
            var brandsResponse = brands.Select(BrandResponse.MapFromTheEntity);

            return Response<IEnumerable<BrandResponse>>.Success(brandsResponse);
        }
    }
}
