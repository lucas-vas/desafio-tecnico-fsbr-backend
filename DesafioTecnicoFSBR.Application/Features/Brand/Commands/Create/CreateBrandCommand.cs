﻿using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using MediatR;

namespace DesafioTecnicoFSBR.Application.Features.Brand.Commands.Create
{
    public sealed record CreateBrandCommand : IRequest<Response<BrandResponse>>
    {
        public string Name { get; set; }
    }
}
