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
using TaskTracker.ViewModels.Json.Task;
using TaskTracker.ViewModels.Json.User;

namespace TaskTracker.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class WorkTaskUserController : ApiController
    {
        private readonly IWorkTaskUserService _userService;
        private readonly IWorkTaskService _taskService;
        private readonly IMapper<WorkTaskUserDto, WorkTaskUserViewModel>
            _userModelMapper;
        private readonly IMapper<WorkTaskDto, WorkTaskViewModel> 
            _taskModelMapper;

        public WorkTaskUserController(IWorkTaskUserService workTaskUserService,
            IWorkTaskService workTaskService,
            IMapper<WorkTaskUserDto, WorkTaskUserViewModel> userModelMapper,
            IMapper<WorkTaskDto, WorkTaskViewModel> taskModelMapper)
        {
            _userService = workTaskUserService;
            _userModelMapper = userModelMapper;
            _taskService = workTaskService;
            _taskModelMapper = taskModelMapper;
        }

        [HttpGet]
        [Route("info")]
        public async Task<WorkTaskUserViewModel> GetCurrentUserInfo()
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

        [HttpGet]
        [Route("{id}/info")]
        public async Task<WorkTaskUserViewModel> GetUserInfo(int id)
        {
            var result = await _userService.GetWorkTaskUserByIdAsync(id);

            if (!result.Success)
            {
                BadRequest(result.Message);
            }

            var model = _userModelMapper.Map(result.Data);

            return model;
        }

        [HttpPost]
        [Route("info")]
        public async Task<IHttpActionResult> UpdateCurretUserInfo
            (WorkTaskUserViewModel model)
        {
            var userDto = _userModelMapper.Map(model);

            var result = await _userService.UpdateWorkTaskUserAsync(userDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet]
        [Route("tasks/performed")]
        public async Task<IEnumerable<WorkTaskViewModel>> 
            GetAllPerformingTasks()
        {
            var userName = User.Identity.Name;

            var result = await _taskService.GetByPerformerName(userName);

            if(!result.Success)
            {
                BadRequest(result.Message);
            }

            var models = _taskModelMapper.Map(result.Data);

            return models;
        }

        [HttpGet]
        [Route("tasks/managed")]
        public async Task<IEnumerable<WorkTaskViewModel>> 
            GetAllManagedTasks()
        {
            var userName = User.Identity.Name;

            var result = await _taskService.GetByManagerName(userName);

            if (!result.Success)
            {
                BadRequest(result.Message);
            }

            var models = _taskModelMapper.Map(result.Data);

            return models;
        }

    }
}
