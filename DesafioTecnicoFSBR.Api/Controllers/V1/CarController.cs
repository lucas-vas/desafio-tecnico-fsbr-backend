using DesafioTecnicoFSBR.Api.Controllers.Base;
using DesafioTecnicoFSBR.Application.Features.Car.Commands.Create;
using DesafioTecnicoFSBR.Application.Features.Car.Commands.Delete;
using DesafioTecnicoFSBR.Application.Features.Car.Commands.Update;
using DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAll;
using DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAllWithFilter;
using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoFSBR.Api.Controllers.V1
{
    public sealed class CarController : BaseController
    {
        [HttpPost("Create")]
        public async Task<ActionResult<Response<CarResponse>>> Create([FromBody] CreateCarCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Response<CarResponse>>> Update([FromBody] UpdateCarCommand command)
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
            var command = new DeleteCarCommand
            {
                Id = id
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Response<IEnumerable<CarResponse>>>> GetAll()
        {
            GetAllCarsQuery query = new();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllWithFilter")]
        public async Task<ActionResult<Response<IEnumerable<CarResponse>>>> GetAllWithFilter([FromQuery] GetAllCarsWithFilterQuery query)
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
