using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Application.Contracts.Identity;
using QIMSchoolPro.Thesis.Application.Features.MyUser.Queries;
using QIMSchoolPro.Thesis.Application.Models.Identity;
using QIMSchoolPro.Thesis.Processors.Processors;
using QIMSchoolProThesisService.Controllers.Base;

namespace QIMSchoolProThesisService.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        //private readonly IAuthService _authenticationService;
        public AccountController()
        {
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet()]
        public async Task<UserViewModel> UserInfo()
        {

            return await Mediator.Send(new GetLoginUser.Query());
        }

        //[HttpPost("login")]
        //public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        //{
        //    return Ok(await _authenticationService.Login(request));
        //}

        //[HttpPost("register")]
        //public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        //{
        //    return Ok(await _authenticationService.Register(request));
        //}
    }
}
