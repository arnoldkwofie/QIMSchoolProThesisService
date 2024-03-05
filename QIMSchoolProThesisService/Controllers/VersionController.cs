using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries;
using QIMSchoolPro.Thesis.Application.Features.MyVersion.VersionCommands;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    public class VersionController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromForm] VersionCreate.Command command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteVersion.Command { Id = id });
            return NoContent();
        }


    }
}
