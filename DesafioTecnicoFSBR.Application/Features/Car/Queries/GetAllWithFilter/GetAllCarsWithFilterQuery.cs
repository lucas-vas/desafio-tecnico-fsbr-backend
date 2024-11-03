using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAllWithFilter
{
    public sealed record GetAllCarsWithFilterQuery : IRequest<Response<IEnumerable<CarResponse>>>
    {
        public string? ModelDescription { get; set; }
        public int? Year { get; set; }
        public Guid? BrandId { get; set; }
    }
}
