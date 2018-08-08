using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using TaskTracker.Bll.Abstract.Messaging.Notifications;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Common.Enums;
using TaskTracker.Common.Results;
using TaskTracker.Dal.Impl.Ef.Base;
using TaskTracker.Dto;
using TaskTracker.Mapping.Base;
using TaskTracker.Messaging.Entities;
using TaskTracker.ViewModels.Json.Auth;
using TaskTracker.ViewModels.Json.User;
using TaskTracker.WebApi.Models;

namespace TaskTracker.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/account")]
    public class UsersAccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private readonly ITemplateSender _templateSender;
        private readonly IWorkTaskUserService _userService;
        private readonly ILeftSideMapper
            <RegisterUserViewModel, WorkTaskUserDto> _registerModelMapper;

        public UsersAccountController(ITemplateSender templateSender,
            IWorkTaskUserService workTaskUserService,
            ILeftSideMapper<RegisterUserViewModel, WorkTaskUserDto> registerModelMapper)
        {
            _templateSender = templateSender;
            _userService = workTaskUserService;
            _registerModelMapper = registerModelMapper;
        }

        public UsersAccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat,
            ITemplateSender templateSender,
            ILeftSideMapper<RegisterUserViewModel, WorkTaskUserDto> registerModelMapper,
            IWorkTaskUserService workTaskUserService)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            _templateSender = templateSender;
            _registerModelMapper = registerModelMapper;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat
        { get; private set; }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> Login(LoginUserViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid user data.");
            }

            var testServer = TestServer.Create<Startup>();
            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.Name),
                new KeyValuePair<string, string>("password", model.Password)
            };
            var requestParamsFormUrlEncoded = new FormUrlEncodedContent
                (requestParams);

            var tokenServiceResponse = await testServer.HttpClient
                .PostAsync("/Token", requestParamsFormUrlEncoded);

            return ResponseMessage(tokenServiceResponse);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterUserViewModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Invalid user data");
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Name,
                Email = model.Email
            };

            var identityResult = await UserManager.CreateAsync
                (user, model.Password);

            if (!identityResult.Succeeded)
            {
                return GetErrorResult(identityResult);
            }

            var loginResult = Login(new LoginUserViewModel
            {
                Name = model.Name,
                Password = model.Password
            });

            var systemMailEntity = new SystemMailEntity
            {
                From = "vladislavcepes98@gmail.com",
                FromName = "Admin",
                To = model.Email,
                ToName = model.Name
            };

            var workTaskUserDto = _registerModelMapper.Map(model);

            var userCreationResult = await _userService.CreateWorkTaskUserAsync
                (workTaskUserDto);

            if (!userCreationResult.Success)
            {
                return BadRequest(userCreationResult.Message);
            }

            /*await _templateSender.SendAsync(
                MessageTemplateType.RegistrationConfirm,
                systemMailEntity, null);*/

            return await loginResult;
        }

        [HttpPost]
        [Route("logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok(new { message = "Logout successful." });
        }


        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                { 
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

    }
    
}
    