using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    public class SubmissionController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromForm] Create.Command command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionDto>> Gets()
        {
            return await Mediator.Send(new GetSubmissions.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<SubmissionDto> Get(int id)
        {
            return await Mediator.Send(new GetSubmission.Query(id));
        }
    }
}
