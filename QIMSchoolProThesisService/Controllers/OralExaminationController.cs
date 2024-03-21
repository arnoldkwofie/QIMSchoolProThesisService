using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Features.MyGrade.Commands;
using QIMSchoolPro.Thesis.Application.Features.MyOralExamination.Commands;
using QIMSchoolPro.Thesis.Application.Features.MyStaff.Queries;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries;
using QIMSchoolPro.Thesis.Application.Features.MyThesisAssignment.ThesisAssignmentCommands;
using QIMSchoolPro.Thesis.Application.Features.MyVersion.VersionCommands;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Processors.Dtos;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    [Authorize]
    public class OralExaminationController : BaseController
    {
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Schedule(Schedule.MyScheduleCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<OralExaminationDto>> GetAll()
        {
            return await Mediator.Send(new GetAll.Query());
        }

    }
}
