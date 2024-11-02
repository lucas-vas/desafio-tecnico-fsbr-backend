using DesafioTecnicoFSBR.Api.Controllers.Base;
using DesafioTecnicoFSBR.Application.Features.Brand.Commands.Create;
using DesafioTecnicoFSBR.Application.Features.Brand.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoFSBR.Api.Controllers.V1
{
    public sealed class BrandController : BaseController
    {
        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult<BrandResponse>> Create([FromBody] CreateBrandCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        //[HttpPut("Update")]
        //public async Task<ActionResult<BrandResponse>> Update()
        //{

        //}

        //[HttpDelete("Delete/{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{

        //}

        //[HttpGet("GetAll")]
        //public async Task<ActionResult<List<BrandResponse>>> GetAll()
        //{

        //}
    }
}
