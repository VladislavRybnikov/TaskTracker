using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Dto;
using TaskTracker.Mapping.Base;
using TaskTracker.ViewModels.Json.User;

namespace TaskTracker.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class WorkTaskUserController : ApiController
    {
        private readonly IWorkTaskUserService _userService;
        private readonly IMapper<WorkTaskUserDto, WorkTaskUserViewModel>
            _userModelMapper;

        public WorkTaskUserController(IWorkTaskUserService workTaskUserService,
            IMapper<WorkTaskUserDto, WorkTaskUserViewModel> userModelMapper)
        {
            _userService = workTaskUserService;
            _userModelMapper = userModelMapper;
        }

        [HttpGet]
        [Route("info")]
        public async Task<WorkTaskUserViewModel> UserInfo()
        {
            var userName = User.Identity.Name;

            var userFindResult = await _userService
                .GetWorkTaskUserByNameAsync(userName);

            if(!userFindResult.Success)
            {
                BadRequest(userFindResult.Message);
            }

            var userModel = _userModelMapper.Map(userFindResult.Data);

            return userModel;
        }
    }
}
