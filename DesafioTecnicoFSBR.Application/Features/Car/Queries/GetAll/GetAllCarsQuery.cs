using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAll
{
    public class GetAllCarsQuery : IRequest<IEnumerable<CarResponse>>
    {
    }
}
