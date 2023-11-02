using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Commands;
using QIMSchoolPro.Thesis.Application.Features.MySubmission.Queries;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    public class SubmissionHistoryController : BaseController
    {
        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<SubmissionHistoryDto>> GetSubmissionHistoryBySubmissionId(int id)
        {
            return await Mediator.Send(new GetSubmissionHistoryBySubmissionId.Query(id));
        }

    }
}
