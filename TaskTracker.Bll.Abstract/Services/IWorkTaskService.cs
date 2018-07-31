using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Results;
using TaskTracker.Dto;

namespace TaskTracker.Bll.Abstract.Services
{
    /// <summary>
    /// Main service for WorkTasks. 
    /// </summary>
    public interface IWorkTaskService
    {
        Task<Result> UpdateWorkTaskProgressAsync(WorkTaskDto workTaskDto,
            WorkTaskProgressDto progressDto);
        Task<Result> CreateWorkTaskAsync(WorkTaskDto workTaskDto);
        Task<Result> ChangeDescriptionAsync
            (WorkTaskDto workTaskDto, string description);
        Task<Result> AddPerformerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto performer);
        Task<Result> ChangeManagerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto manager);
        Task<DataResult<WorkTaskDto>> GetWorkTaskAsync
            (string name, WorkTaskUserDto manager);
        Task<Result> AddWorkTaskPoint(WorkTaskDto workTaskDto,
            WorkTaskPointDto workTaskPointDto);
    }
}
