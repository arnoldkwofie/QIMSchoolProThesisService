using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries;
using QIMSchoolPro.Thesis.Application.Features.MyThesisAssignment.ThesisAssignmentCommands;
using QIMSchoolPro.Thesis.Application.Features.MyVersion.VersionCommands;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    [Authorize]
    public class SubmissionController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromForm] SubmissionCreate.Command command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> PostSubmission(PostSubmission.PostSubmissionCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}


		[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionDto>> GetUserSubmissions()
        {
            return await Mediator.Send(new GetUserSubmissions.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DepartmentApproval(int submissionid, int approvalId)
        {
            await Mediator.Send(new DeapartmentApproval.Query(submissionid, approvalId));
           return NoContent();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionDto>> GetDepartmentSubmissions()
        {
            return await Mediator.Send(new GetDepartmentSubmissions.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionDto>> GetDepartmentProcessedReviews()
        {
            return await Mediator.Send(new GetDepartmentProcessedReviews.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionDto>> GetSPSProcessedReviews()
        {
            return await Mediator.Send(new GetSPSProcessedReviews.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionDto>> GetReportSubmissions()
        {
            return await Mediator.Send(new GetReportSubmissions.Query());
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionDto>> GetSPSSubmissions()
        {
            return await Mediator.Send(new GetSPSSubmissions.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<SubmissionDto> Get(int id)
        {
            return await Mediator.Send(new GetSubmission.Query(id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSubmission.Command { Id = id });
            return NoContent();
        }
    }
}
