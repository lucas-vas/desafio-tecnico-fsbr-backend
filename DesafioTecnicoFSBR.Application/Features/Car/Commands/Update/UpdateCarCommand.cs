using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Update
{
    public sealed record UpdateCarCommand : IRequest<CarResponse>
    {
        public Guid Id { get; set; }
        public string ModelDescription { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }
        public Guid BrandId { get; set; }
    }
}
