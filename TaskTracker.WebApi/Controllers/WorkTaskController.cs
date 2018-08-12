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
    [RoutePrefix("api/task")]
    public class WorkTaskController : ApiController
    {
        private readonly IWorkTaskService _workTaskService;
        private readonly IMapper<WorkTaskDto, WorkTaskViewModel>
            _taskModelMapper;

        public WorkTaskController(IWorkTaskService workTaskService,
            IMapper<WorkTaskDto, WorkTaskViewModel> taskModelMapper)
        {
            _workTaskService = workTaskService;
            _taskModelMapper = taskModelMapper;
        }

        [HttpGet]
        [Route("{id}/info")]
        public Task<WorkTaskUserViewModel> GetWorkTaskInfo(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("{id}/info")]
        public Task<WorkTaskUserViewModel> UpdateWorkTaskInfo
            (int id, WorkTaskUserViewModel model)
        {
            return null;
        }

        [HttpPost]
        [Route("{id}/performers")]
        public IHttpActionResult AddPerformer(int id, string performerName)
        {
            return null;
        }

        [HttpGet]
        [Route("{id}/performers")]
        public IHttpActionResult GetPerformers(int id)
        {
            return null;
        }

        [HttpGet]
        [Route("{id}/performers")]
        public IHttpActionResult GetPerformers(int id)
        {
            return null;
        }

    }
}
