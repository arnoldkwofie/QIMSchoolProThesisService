using MediatR;
using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries;
using QIMSchoolPro.Thesis.Application.Features.MyThesisAssignment.ThesisAssignmentCommands;
using QIMSchoolPro.Thesis.Application.Features.MyVersion.VersionCommands;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Processors.Processors;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    public class ThesisAssignmentController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(ThesisAssignmentCreate.Command command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ThesisAssignmentDto>> GetExaminerProcessedReviews()
        {
            return await Mediator.Send(new GetExaminerProcessedReviews.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ThesisAssignmentDto>> GetByStaffId()
        {
            return await Mediator.Send(new GetByStaffId.Query());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ThesisAssignmentDto>> GetApprovedByStaffId()
        {
            return await Mediator.Send(new GetApprovedByStaffId.Query());
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Decide(MakeDecision.Commandx command)
        {
            await Mediator.Send(command);
            return NoContent();
        }


    }


}



