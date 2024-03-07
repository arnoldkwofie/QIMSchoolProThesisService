using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Features.MyStaff.Queries;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries;
using QIMSchoolPro.Thesis.Application.Features.MyThesisAssignment.ThesisAssignmentCommands;
using QIMSchoolPro.Thesis.Application.Features.MyVersion.VersionCommands;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    [Authorize]
    public class GradeController : BaseController
    {
        

		[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<GradeParamDto>> GetGradeParams()
        {
            return await Mediator.Send(new GetGradeParams.Query());
        }

       
    }
}
