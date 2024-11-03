using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAll
{
    public class GetAllCarsQuery : IRequest<Response<IEnumerable<CarResponse>>>
    {
    }
}
