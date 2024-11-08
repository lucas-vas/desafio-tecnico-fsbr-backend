﻿using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Car.Commands.Create
{
    public sealed record CreateCarCommand : IRequest<Response<CarResponse>>
    {
        public string ModelDescription { get; set; }
        public int Year { get; set; }
        public double Value {  get; set; }
        public Guid BrandId { get; set; }
    }
}
