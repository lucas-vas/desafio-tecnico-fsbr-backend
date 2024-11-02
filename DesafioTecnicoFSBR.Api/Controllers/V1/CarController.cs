using DesafioTecnicoFSBR.Api.Controllers.Base;
using DesafioTecnicoFSBR.Application.Features.Car.Commands.Create;
using DesafioTecnicoFSBR.Application.Features.Car.Queries.GetAll;
using DesafioTecnicoFSBR.Application.Features.Car.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoFSBR.Api.Controllers.V1
{
    public sealed class CarController : BaseController
    {
        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult<CarResponse>> Create([FromBody] CreateCarCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        //[HttpPut("Update")]
        //[Authorize]
        //public async Task<ActionResult<CarResponse>> Update()
        //{

        //}

        //[HttpDelete("Delete/{id}")]
        //[Authorize]
        //public async Task<ActionResult> Delete(Guid id)
        //{

        //}

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CarResponse>>> GetAll()
        {
            GetAllCarsQuery query = new();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
