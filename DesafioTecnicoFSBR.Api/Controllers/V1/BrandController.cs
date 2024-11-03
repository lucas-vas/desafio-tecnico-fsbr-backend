using DesafioTecnicoFSBR.Api.Controllers.Base;
using DesafioTecnicoFSBR.Application.Features.Brand.Commands.Create;
using DesafioTecnicoFSBR.Application.Features.Brand.Commands.Delete;
using DesafioTecnicoFSBR.Application.Features.Brand.Commands.Update;
using DesafioTecnicoFSBR.Application.Features.Brand.Queries.GetAll;
using DesafioTecnicoFSBR.Application.Features.Brand.Queries.GetAllWithFilter;
using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoFSBR.Api.Controllers.V1
{
    public sealed class BrandController : BaseController
    {
        [HttpPost("Create")]
        public async Task<ActionResult<Response<BrandResponse>>> Create([FromBody] CreateBrandCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Response<BrandResponse>>> Update([FromBody] UpdateBrandCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Response<string>>> Delete(Guid id)
        {
            var command = new DeleteBrandCommand
            {
                Id = id
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Response<IEnumerable<BrandResponse>>>> GetAll()
        {
            GetAllBrandsQuery query = new();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllWithFilter")]
        public async Task<ActionResult<Response<IEnumerable<BrandResponse>>>> GetAllWithFilter([FromQuery] GetAllBrandsWithFilterQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
